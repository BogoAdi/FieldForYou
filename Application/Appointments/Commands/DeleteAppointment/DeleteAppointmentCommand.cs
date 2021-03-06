using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest<Appointment>
    {
        public Guid Id { get; set; }
    }
}
