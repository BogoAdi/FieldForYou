using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<Appointment>
    {
        public Guid Id { get; set; }
        public Guid SportFieldId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public double TotalPrice { get; set; }
        public User User { get; set; }
        public SportField SportField { get; set; }
    }
}
