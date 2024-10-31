using AutoMapper;
using EagleTask.Data.Repositories.RepositoriesInterfaces;
using EagleTask.Models.Models.Domains;
using EagleTask.Models.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EagleTask.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<UserDto>>> GetAll()
        {
            IEnumerable<User> users = await _unitOfWork.Repository<User>().GetAllAsync();

            if (users.ToList().Count == 0)
            {
                return NotFound("There is no users to show!");
            }

            return Ok(_mapper.Map<IReadOnlyList<UserDto>>(users));
        }
    }
}
