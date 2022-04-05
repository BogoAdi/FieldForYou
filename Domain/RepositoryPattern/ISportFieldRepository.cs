namespace Domain.RepositoryPattern
{
    public interface ISportFieldRepository
    {
        public Task AddSportFieldAsync(SportField sportField, CancellationToken cancellationToken);
        public Task DeleteSportFieldAsync(SportField sportField, CancellationToken cancellationToken);

        public Task<List<SportField>> GetAllSportFieldsAsync(CancellationToken cancellationToken);
        public Task<SportField> GetSportFieldByIdAsync(Guid id, CancellationToken cancellationToken);
       
    }
}
