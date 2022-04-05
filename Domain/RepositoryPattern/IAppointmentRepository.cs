namespace Domain.RepositoryPattern
{
    public interface IAppointmentRepository
    {
        void AddAppointment(Appointment appointment);
        void RemoveAppointment(Appointment appointment);
        void ShowAll();
        Appointment GetAppointment(Appointment appointment);
    }
}
