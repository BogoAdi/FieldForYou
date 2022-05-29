

using Domain;
using System.ComponentModel.DataAnnotations;

namespace SportFieldScheduler.Application.Dto
{
    public class SportFieldPostDto
    {
        [Required]
        
        public string Name { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        
        public string City { get; set; }
        [Required]
        public double PricePerHour { get; set; }
        [Required]
        public SportFieldCategory Category { get; set; }
        [Required]

        public string? Description { get; set; }
        public string Img { get; set; }

    }
}