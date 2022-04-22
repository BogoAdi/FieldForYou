using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SportFields.Commands.DeleteSportField
{
    public class DeleteSportFieldCommandHandler : IRequestHandler<DeleteSportFieldCommand, SportField>
    {
        private readonly ISportFieldRepository _repository;

        public DeleteSportFieldCommandHandler(ISportFieldRepository repository)
        {
            _repository = repository;
        }

        public async Task<SportField> Handle(DeleteSportFieldCommand command, CancellationToken cancellationToken)
        {
            var deleted = await _repository.DeleteSportFieldAsync(command.Id, cancellationToken);

            return await Task.FromResult(deleted);
        }
    }
}
