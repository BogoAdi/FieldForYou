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
            //logic for allowing free dates
            bool freeSlot = true;

            foreach (Appointment appointment1 in _context.Appointments)
            {
                if (appointment.SportFieldId == appointment1.SportFieldId)
                {
                    if (appointment.Date >= appointment1.Date &&
                        appointment1.Date.AddHours(Convert.ToDouble(appointment1.Hours))
                        > appointment.Date)
                    {
                        freeSlot = false;
                        break;
                    }
                    if (appointment.Date < appointment1.Date &&
                       appointment.Date.AddHours(Convert.ToDouble(appointment1.Hours))
                       > appointment1.Date)
                    {
                        freeSlot = false;
                        break;
                    }

                }

            }
            // Console.WriteLine();
            // Console.WriteLine(freeSlot);
            // Console.WriteLine();
            if (freeSlot)
            {
                var res = _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

            }
            var isAdded = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == appointment.Id);
            return isAdded;
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
