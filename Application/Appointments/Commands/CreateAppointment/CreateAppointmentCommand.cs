using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : Entity, IRequest<Guid>
    {

        public Guid IdField { get; set; }
        public Guid IdUser { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public double TotalPrice { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
