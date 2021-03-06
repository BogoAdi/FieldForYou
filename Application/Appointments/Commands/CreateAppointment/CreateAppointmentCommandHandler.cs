using Domain;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Commands.CreateAppointment
{
        public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Appointment>
        {
            private IAppointmentRepository _repository;
            private ISportFieldRepository _sportFieldRepository;
            public CreateAppointmentCommandHandler(IAppointmentRepository repository, ISportFieldRepository sportFieldRepository)
            {
                _repository = repository;        
                _sportFieldRepository = sportFieldRepository;
            }

            public async Task<Appointment> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
            {
            var sportfield = await _sportFieldRepository.GetSportFieldByIdAsync(command.SportFieldId,cancellationToken);

            var appointment = new Appointment
                {
                    Id = command.Id,
                    SportFieldId = command.SportFieldId,
                    UserId = command.UserId,
                    Date = command.Date,
                    Hours = command.Hours,
                    TotalPrice = sportfield.PricePerHour * command.Hours
                //SportField = command.SportField,
                // User = command.User
            };
                var res = await _repository.AddAppointmentAsync(appointment, cancellationToken);
                return await Task.FromResult(res);
            }
        }
}
