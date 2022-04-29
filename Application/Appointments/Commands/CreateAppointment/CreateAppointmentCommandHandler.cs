using Domain;
using Domain.Interfaces;
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

            public CreateAppointmentCommandHandler(IAppointmentRepository repository)
            {
                _repository = repository;
            }

            public async Task<Appointment> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
            {
                var appointment = new Appointment
                {
                    Id = command.Id,
                    SportFieldId = command.SportFieldId,
                    UserId = command.UserId,
                    Date = command.Date,
                    Hours = command.Hours,
                    TotalPrice = command.TotalPrice,
                    SportField = command.SportField,
                    User = command.User,
                    Img = command.Img,
                };
                var res = await _repository.AddAppointmentAsync(appointment, cancellationToken);
                return await Task.FromResult(res);
            }
        }
}
