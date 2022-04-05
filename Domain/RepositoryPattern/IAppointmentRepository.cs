namespace Domain.RepositoryPattern
{
    public interface IAppointmentRepository
    {
        public Task AddAppointmentAsync(Appointment appointment, CancellationToken cancellationToken);
        public Task RemoveAppointmentAsync(Appointment appointment, CancellationToken cancellationToken);
        public Task<List<Appointment>> GetAllAppointmentsAsync(CancellationToken cancellationToken);
        public Task<Appointment> GetAppointmentByIdAsync(Appointment appointment, CancellationToken cancellationToken);
    }
}
