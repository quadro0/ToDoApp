using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ICategoriesRepository : IRepository<CategoryEntity>
    {
        Task<CategoryEntity?> GetByNameAsync(Guid userId, string name);
        Task<IEnumerable<CategoryEntity>> GetAllAsync(Guid userId);
    }
}
