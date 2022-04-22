namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
        public Task<User> RemoveUserAsync(Guid id, CancellationToken cancellationToken);
        public Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<List<User>> GetAllUserAsync( CancellationToken cancellationToken);
        public Task<User> UpdateUserASync(Guid id, User user, CancellationToken cancellationToken);
    }
}
