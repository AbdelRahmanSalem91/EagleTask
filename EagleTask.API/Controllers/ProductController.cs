using AutoMapper;
using EagleTask.Data.Repositories.RepositoriesInterfaces;
using EagleTask.Models.Models.Domains;
using EagleTask.Models.Models.DTOs;
using EagleTask.Models.Models.DTOs.AddDTOs;
using EagleTask.Models.RepositoriesInterfaces;
using EagleTask.Models.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace EagleTask.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll()
        {
            ProductSpecifications specs = new ProductSpecifications();
            IEnumerable<Product> products = await _unitOfWork.Repository<Product>().GetAllAsync(specs);

            if (products.ToList().Count == 0)
            {
                return NotFound("There is no products to show!");
            }
            return Ok(_mapper.Map<IReadOnlyList<ProductDto>>(products));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Add([FromBody] AddProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            product.CategoryId = productDto.CategoryId;

            product.BrandId = productDto.BrandId;

            await _unitOfWork.Repository<Product>().AddAsync(product);
            _unitOfWork.Save();

            return Created("", _mapper.Map<ProductDto>(product));
        }
    }
}
