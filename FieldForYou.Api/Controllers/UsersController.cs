using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserByIdQuery;
using AutoMapper;
using Domain;
using FieldForYou.Api.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FieldForYou.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public UsersController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(UserPutPostDto user)
        {
            var command = _mapper.Map<UserPutPostDto, CreateUserCommand>(user);
            var created = await _mediator.Send(command);
            var dto = _mapper.Map<User, UserGetDto>(created);
            return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, dto);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            var mappedResult = _mapper.Map<User, UserGetDto>(result);
            return Ok(mappedResult);
        }
    }
        
}
