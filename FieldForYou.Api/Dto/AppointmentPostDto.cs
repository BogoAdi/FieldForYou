namespace FieldForYou.Api.Dto
{
    public class AppointmentPostDto
    {
        public Guid SportFieldId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public double TotalPrice { get; set; }
    }
}
