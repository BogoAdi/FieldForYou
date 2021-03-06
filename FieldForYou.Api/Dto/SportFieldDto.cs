using Domain;

namespace FieldForYou.Api.Dto
{
    public class SportFieldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double PricePerHour { get; set; }
        public string? Description { get; set; }
        public string Img { get; set; }
        public SportFieldCategory Category { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
