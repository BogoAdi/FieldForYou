using Domain;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly FieldForYouContext _context;

        public AppointmentRepository(FieldForYouContext context)
        {
            _context = context;
        }

        public async Task<Appointment> AddAppointmentAsync(Appointment appointment, CancellationToken cancellationToken)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> RemoveAppointmentAsync(Guid id, CancellationToken cancellationToken)
        {
            var appointmentToBeDeleted = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            if (appointmentToBeDeleted == null) { return null; }

            _context.Appointments.Remove(appointmentToBeDeleted);
            await _context.SaveChangesAsync();
            return appointmentToBeDeleted;
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var found = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            if(found == null) { return null; }
            return found;
        }

       

    }
}
