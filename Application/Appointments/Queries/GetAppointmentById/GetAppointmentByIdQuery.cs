using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Queries.GetAppointmentById
{
    public class GetAppointmentByIdQuery : IRequest<Appointment>
    {
        public Guid Id { get; set; }
    }
}
