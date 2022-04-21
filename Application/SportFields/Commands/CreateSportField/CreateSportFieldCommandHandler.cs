using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SportFields.Commands.CreateSportField
{
    public class CreateSportFieldCommandHandler : IRequestHandler<CreateSportFieldCommand, SportField>
    {
        private readonly ISportFieldRepository _repository;

        public CreateSportFieldCommandHandler(ISportFieldRepository repository)
        {
            _repository = repository;
        }

        public async Task<SportField> Handle(CreateSportFieldCommand command, CancellationToken cancellationToken)
        {
            SportField sportField = new SportField()
            {
                Id = command.Id,
                Address = command.Address,
                Appointments = command.Appointments,
                Category = command.Category,
                City = command.City,
                Description = command.Description,
                Name = command.Name,
                PricePerHour = command.PricePerHour
            };

            var res = await _repository.AddSportFieldAsync(sportField, cancellationToken);
            return await Task.FromResult(res);
        }
    }
}
