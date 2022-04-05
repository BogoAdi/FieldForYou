namespace Domain.RepositoryPattern
{
    public interface IUserRepository
    {
        public Task AddUserAsync(User user, CancellationToken cancellationToken);
        public Task RemoveUserAsync(User user, CancellationToken cancellationToken);
        public Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<List<User>> GetAllUserAsync( CancellationToken cancellationToken);
    }
}
