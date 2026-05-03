using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UsersRepository(TodoDbContext context) : IUsersRepository
    {
        private readonly TodoDbContext context = context;

        public async Task<UserEntity?> GetByIdAsync(Guid id)
        {
            return await context.Users.AsNoTracking().Include(u => u.Tasks).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await context.Users.AsNoTracking().Include(u => u.Tasks).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await context.Users.AsNoTracking().Include(u => u.Tasks).ToListAsync();
        }

        public void Add(UserEntity user)
        {
           context.Users.Add(user);
        }

        public void Delete(UserEntity entity)
        {
            context.Users.Remove(entity);
        }

        public void Update(UserEntity user)
        {
            context.Users.Update(user);
        }
    }
}
