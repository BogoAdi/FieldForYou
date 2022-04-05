namespace Domain.RepositoryPattern
{
    public interface ISportFieldRepository
    {
        void AddSportField(SportField sportField);
        void ShowAll();
        void DeleteSportField(SportField sportField);
        void ShowAllAppointments(SportField s1);
        SportField GetSportField(string sportFieldName);
        void AddAppointment(Appointment appointment,SportField sportField);
    }
}
