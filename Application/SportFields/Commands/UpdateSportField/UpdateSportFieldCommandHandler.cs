using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SportFields.Commands.UpdateSportField
{
    public class UpdateSportFieldCommandHandler : IRequestHandler<UpdateSportFieldCommand, SportField>
    {
        private readonly ISportFieldRepository _repository;

        public UpdateSportFieldCommandHandler(ISportFieldRepository repository)
        {
            _repository = repository;
        }

        public async Task<SportField> Handle(UpdateSportFieldCommand command, CancellationToken cancellationToken)
        {
            var sportField = new SportField
            {
                Id = command.Id,
                Address = command.Address,
                City = command.City,
                Category = command.Category,
                Name = command.Name,
                Description = command.Description,
                PricePerHour = command.PricePerHour,
                Img = command.Img,
                Appointments = command.Appointments
            };

            var res = await _repository.UpdateSpotFieldASync(command.Id, sportField, cancellationToken);
            return await Task.FromResult(res);
        }
    }
}
