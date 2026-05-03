using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CategoriesRepository(TodoDbContext context) : ICategoriesRepository
    {
        private readonly TodoDbContext context = context;

        public async Task<CategoryEntity?> GetByIdAsync(Guid id)
        {
            return await context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CategoryEntity?> GetByNameAsync(Guid userId, string name)
        {
            return await context.Categories.AsNoTracking().Where(c => c.UserId == userId).FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllAsync(Guid userId)
        {
            return await context.Categories.AsNoTracking().Where(c => c.UserId == userId).Include(c => c.Tasks).ToListAsync();
        }

        public void Add(CategoryEntity category)
        {
            context.Categories.Add(category);
        }

        public void Update(CategoryEntity category)
        {
            context.Categories.Update(category);
        }

        public void Delete(CategoryEntity entity)
        {
            context.Categories.Remove(entity);
        }
    }
}
