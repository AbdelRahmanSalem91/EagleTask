using AutoMapper;
using EagleTask.Data.Repositories.RepositoriesInterfaces;
using EagleTask.Models.Models.Domains;
using EagleTask.Models.Models.DTOs;
using EagleTask.Models.Models.DTOs.AddDTOs;
using EagleTask.Models.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EagleTask.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Customer> customers = await _unitOfWork.Repository<Customer>().GetAllAsync();

            if (customers.ToList().Count == 0)
            {
                return NotFound("There is no customers to show!");
            }

            return Ok(_mapper.Map<List<CustomerDto>>(customers));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody]AddCustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            await _unitOfWork.Repository<Customer>().AddAsync(customer);
            _unitOfWork.Save();

            return Created("",_mapper.Map<CustomerDto>(customer));
        }
    }
}
