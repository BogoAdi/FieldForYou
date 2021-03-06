using Domain;

namespace FieldForYou.Api.Dto
{
    public class UserGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public List<Appointment> Appointments { get; set; }
        public Role Role { get; set; }
    }
}
