using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SportField : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double PricePerHour { get; set; }
        public SportFieldCategory Category { get; set; }
        public string? Description { get; set; }
        public string Img { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
            
        public override string ToString()
        {
            return Address + " " + City + " " + PricePerHour + " " + Category+ " "+Id;
        }
    }
}
