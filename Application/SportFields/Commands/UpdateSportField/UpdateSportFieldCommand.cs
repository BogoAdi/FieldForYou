using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SportFields.Commands.UpdateSportField
{
    public class UpdateSportFieldCommand : IRequest<SportField>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double PricePerHour { get; set; }
        public  string Img { get; set; }
        public SportFieldCategory Category { get; set; }
        public string? Description { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
