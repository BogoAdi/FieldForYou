namespace Domain.Interfaces
{
    public interface ISportFieldRepository
    {
        public Task<SportField> AddSportFieldAsync(SportField sportField, CancellationToken cancellationToken);
        public Task<SportField> DeleteSportFieldAsync(Guid id, CancellationToken cancellationToken);

        public Task<List<SportField>> GetAllSportFieldsAsync(CancellationToken cancellationToken);
        public Task<SportField> GetSportFieldByIdAsync(Guid id, CancellationToken cancellationToken);
       
    }
}
