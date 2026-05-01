using Data.Entities;
using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class TasksRepository(TodoDbContext context) : ITasksRepository
    {
        private readonly TodoDbContext context = context;

        public async Task<TaskEntity?> GetByIdAsync(Guid id)
        {
            return await context.Tasks.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await context.Tasks.AsNoTracking().ToListAsync();
        }

        public void Add(TaskEntity task)
        {
            context.Tasks.Add(task);
        }

        public void Delete(TaskEntity task)
        {
            context.Tasks.Remove(task);
        }

        public void Update(TaskEntity task)
        {
            context.Tasks.Update(task);
        }

        public async Task<PagedResult<TaskEntity>> GetPaginatedTasksAsync(TasksPaginationParameters paginationParameters)
        {
            var result = context.Tasks.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(paginationParameters.SearchName))
            {
                result = result.Where(t => t.Name!.Contains(paginationParameters.SearchName));
            }

            if (paginationParameters.CategoryId != null)
            {
                result = result.Where(t => t.CategoryId == paginationParameters.CategoryId);
            }

            var totalCount = await result.CountAsync();

            var skipCount = (paginationParameters.PageNumber - 1) * paginationParameters.PageSize;

            var items = await result.Skip(Math.Max(0, skipCount)).Take(paginationParameters.PageSize).ToListAsync();

            return new PagedResult<TaskEntity>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = paginationParameters.PageNumber,
                PageSize = paginationParameters.PageSize
            };
        }
    }
}
