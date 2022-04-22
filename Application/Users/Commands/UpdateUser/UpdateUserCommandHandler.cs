using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = command.Name,
                Email = command.Email,
                Id = command.Id,
                Appointments = command.Appointments,
                Password = command.Password,
                PhoneNumber = command.PhoneNumber,
                Username = command.Username,
                Role = command.Role
            };
            var res = await _repository.UpdateUserASync(command.Id, user, cancellationToken);
            return await Task.FromResult(res);
        }
    }
}
