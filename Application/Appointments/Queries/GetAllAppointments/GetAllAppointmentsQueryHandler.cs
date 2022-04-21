using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, List<Appointment>>
    {
        private readonly IAppointmentRepository _repository;

        public GetAllAppointmentsQueryHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Appointment>> Handle(GetAllAppointmentsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAppointmentsAsync(cancellationToken);
        }
    }
}
