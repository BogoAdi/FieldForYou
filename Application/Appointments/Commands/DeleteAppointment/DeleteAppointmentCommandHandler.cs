using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Appointment>
    {
        private IAppointmentRepository _repository;

        public DeleteAppointmentCommandHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Appointment> Handle(DeleteAppointmentCommand command, CancellationToken cancellationToken)
        {
            var deleted = await _repository.RemoveAppointmentAsync(command.Id, cancellationToken);

            return await Task.FromResult(deleted);
        }
    }
}
