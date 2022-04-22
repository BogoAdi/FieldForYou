using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = command.Id,
                Appointments = command.Appointments,
                Email = command.Email,
                Name = command.Name,
                Password = command.Password,
                PhoneNumber = command.PhoneNumber,
                Role = command.Role,
                Username = command.Username
            };
            var res = await _repository.AddUserAsync(user, cancellationToken);
            return await Task.FromResult(user);
            
        }
    }
}
