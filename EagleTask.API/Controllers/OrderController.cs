using AutoMapper;
using EagleTask.Data.Repositories.RepositoriesInterfaces;
using EagleTask.Models.Models.Domains;
using EagleTask.Models.Models.DTOs;
using EagleTask.Models.Models.DTOs.AddDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EagleTask.API.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> Add([FromBody] AddOrderDto addOrderDto)
        {
            Order order = _mapper.Map<Order>(addOrderDto);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);

            Product product = await _unitOfWork.Repository<Product>().GetByIdAsync(orderDto.ProductId);
            orderDto.UnitPrice = product.Price;
            orderDto.TotalPrice = orderDto.Quantity * product.Price;

            order.TotalPrice = orderDto.TotalPrice;

            await _unitOfWork.Repository<Order>().AddAsync(order);
            _unitOfWork.Save();

            ProductsOrders productsOrder = new ProductsOrders
            {
                ProductId = addOrderDto.ProductId,
                OrderId = order.Id
            };

            await _unitOfWork.Repository<ProductsOrders>().AddAsync(productsOrder);
            _unitOfWork.Save();

            return Created("", orderDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> GetById(int customerId)
        {
            if (customerId == 0)
            {
                return BadRequest("Please enter the ID field!");
            }
            IReadOnlyList<Order> allOrders = await _unitOfWork.Repository<Order>().GetAllAsync();

            IReadOnlyList<Order> customerOrders = allOrders.Where(o => o.CustomerId == customerId).ToList();

            if (customerOrders.Count == 0)
            {
                return NotFound($"There is no orders for the customer with id {customerId}");
            }
            List<OrderDto> allCustomerOrders = _mapper.Map<IReadOnlyList<OrderDto>>(customerOrders).ToList();

            foreach (OrderDto order in allCustomerOrders)
            {
                Product product = await _unitOfWork.Repository<Product>().GetByIdAsync(order.ProductId);
                order.UnitPrice = product.Price;
                order.TotalPrice = order.Quantity * product.Price;
            }

            return Ok(_mapper.Map<IReadOnlyList<OrderDto>>(allCustomerOrders));
        }
    }
}
