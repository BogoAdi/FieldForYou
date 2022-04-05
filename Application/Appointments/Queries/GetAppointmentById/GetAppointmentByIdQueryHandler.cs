using Domain;
using Domain.RepositoryPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Queries.GetAppointmentById
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, Appointment>
    {
        private IAppointmentRepository _repository;

        public GetAppointmentByIdQueryHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Appointment> Handle(GetAppointmentByIdQuery query, CancellationToken cancellationToken)
        {
            var appointment = _repository.GetAppointmentByIdAsync(query.Appointment, cancellationToken);

            return await appointment;
        }
    }
}
