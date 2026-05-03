using Data.Entities;
using Data.Models;

namespace Data.Repositories.Interfaces
{
    public interface ITasksRepository : IRepository<TaskEntity>
    {
        Task<PagedResult<TaskEntity>> GetPaginatedTasksAsync(Guid userId, TasksPaginationParameters paginationParameters);
    }
}
