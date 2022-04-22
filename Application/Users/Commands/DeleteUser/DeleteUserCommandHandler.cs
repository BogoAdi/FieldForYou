using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var deleted = await _repository.RemoveUserAsync(command.Id, cancellationToken);

            return await Task.FromResult(deleted);
        }
    }
}
