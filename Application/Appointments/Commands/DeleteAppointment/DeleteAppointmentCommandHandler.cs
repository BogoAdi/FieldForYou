using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Guid>
    {
        private IAppointmentRepository _repository;

        public DeleteAppointmentCommandHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteAppointmentCommand command, CancellationToken cancellationToken)
        {
            _repository.RemoveAppointmentAsync(command.Appointment, cancellationToken);

            return await Task.FromResult(command.Appointment.Id);
        }
    }
}
