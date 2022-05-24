using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
namespace Domain
{
    public class Appointment : Entity
    {
        public Guid SportFieldId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public double TotalPrice { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public SportField SportField { get; set; }  
        
        
       
        public override string ToString()
        {
            return "The appointment with the ID: " + Id + "for the date: " + Date + " for " + Hours + " hours ";
        }
    }
}
