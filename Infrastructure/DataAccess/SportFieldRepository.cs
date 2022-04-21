using Domain;
using Domain.Interfaces;

namespace Infrastructure.DataAccess
{
    public class SportFieldRepository : ISportFieldRepository
    {   
        private List<SportField> _fields = new List<SportField>();


        public async Task AddSportFieldAsync(SportField sportField, CancellationToken cancellationToken)
        {
            _fields.Add(sportField);
        }

        public async Task DeleteSportFieldAsync(SportField  sportField, CancellationToken cancellationToken)
        {
            _fields.Remove(sportField);
        }

        public async Task<List<SportField>> GetAllSportFieldsAsync(CancellationToken cancellationToken)
        {
            return _fields;
        }
        
        public async Task<SportField> GetSportFieldByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _fields.FirstOrDefault(x => x.Id == id);
        }
    }
}
