namespace Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        public Task<Appointment> AddAppointmentAsync(Appointment appointment, CancellationToken cancellationToken);
        public Task<Appointment> RemoveAppointmentAsync(Guid id, CancellationToken cancellationToken);
        public Task<List<Appointment>> GetAllAppointmentsAsync(CancellationToken cancellationToken);
        public Task<Appointment> GetAppointmentByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
