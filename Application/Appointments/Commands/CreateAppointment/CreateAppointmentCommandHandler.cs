using Domain;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Commands.CreateAppointment
{
        public class CreateAppointmentCommandHandler : Entity , IRequestHandler<CreateAppointmentCommand, Guid>
        {
            private IAppointmentRepository _repository;

            public CreateAppointmentCommandHandler(IAppointmentRepository repository)
            {
                _repository = repository;
            }

            public async Task<Guid> Handle(CreateAppointmentCommand command, CancellationToken cancellationToken)
            {
                var appointment = new Appointment
                {
                    Id = command.Id,
                    IdField = command.IdField,
                    IdUser = command.IdUser,
                    ClientName = command.ClientName,
                    PhoneNumber = command.PhoneNumber,
                    Date = command.Date,
                    Hours = command.Hours,
                    TotalPrice = command.TotalPrice
                };
                _repository.AddAppointmentAsync(appointment, cancellationToken);
                return await Task.FromResult(appointment.Id);
            }
        }
}
