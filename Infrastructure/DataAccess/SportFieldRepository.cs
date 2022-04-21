using Domain;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class SportFieldRepository : ISportFieldRepository
    {   
        private List<SportField> _fields = new List<SportField>();
        private readonly FieldForYouContext _context;

        public SportFieldRepository(FieldForYouContext context)
        {
            _context = context;
        }

        public async Task<SportField> AddSportFieldAsync(SportField sportField, CancellationToken cancellationToken)
        {
            await _context.SportFields.AddAsync(sportField);
            await _context.SaveChangesAsync();
            return sportField;
        }

        public async Task<SportField> DeleteSportFieldAsync(Guid id, CancellationToken cancellationToken)
        {
            var sportFieldToBeDeleted = await _context.SportFields.FirstOrDefaultAsync(x => x.Id == id);
            if (sportFieldToBeDeleted == null) { return null; }

            _context.SportFields.Remove(sportFieldToBeDeleted);
            await _context.SaveChangesAsync();
            return sportFieldToBeDeleted;
        }

        public async Task<List<SportField>> GetAllSportFieldsAsync(CancellationToken cancellationToken)
        {
            return await _context.SportFields.ToListAsync();
        }
        
        public async Task<SportField> GetSportFieldByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var found = await _context.SportFields.FirstOrDefaultAsync(x => x.Id == id);
            if (found == null) { return null; }
            return found;
        }
    }
}
