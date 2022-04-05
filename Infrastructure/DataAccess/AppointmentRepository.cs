using Domain;
using Domain.RepositoryPattern;

namespace Infrastructure.DataAccess
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private List<Appointment> appointments = new List<Appointment>();

        public async Task AddAppointmentAsync(Appointment appointment, CancellationToken cancellationToken)
        {
            appointments.Add(appointment);
        }

        public async Task RemoveAppointmentAsync(Appointment appointment, CancellationToken cancellationToken)
        {
            appointments.Remove(appointment);
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync(CancellationToken cancellationToken)
        {
            return appointments;
        }

        public async Task<Appointment> GetAppointmentByIdAsync(Appointment appointment, CancellationToken cancellationToken)
        {
            return appointments.SingleOrDefault(x => x.Id == appointment.Id);
        }

       

    }
}
