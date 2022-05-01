using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetAllUsers;
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            var mappedResult = _mapper.Map<List<UserGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPatch("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, UserPutPostDto user)
        {
            var updateUser = new UpdateUserCommand
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Username = user.Username,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Id = userId
            };
            var x = await _mediator.Send(updateUser);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var deleteUser = new DeleteUserCommand
            {
                Id = userId
            };
            await _mediator.Send(deleteUser);
            return NoContent();
        }


    }
        
}
