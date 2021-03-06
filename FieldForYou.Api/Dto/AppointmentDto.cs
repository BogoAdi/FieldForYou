namespace FieldForYou.Api.Dto
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public Guid SportFieldId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public double TotalPrice { get; set; }
        public UserGetDto User { get; set; }
        public SportFieldDto SportField { get; set; }
        
    }
}
