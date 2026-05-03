using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IUsersRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> GetByEmailAsync(string email);
        Task<IEnumerable<UserEntity>> GetAllAsync();
    }
}
