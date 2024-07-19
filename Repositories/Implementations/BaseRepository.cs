using BackEnd_DisciPlanner.Data;
using BackEnd_DisciPlanner.Entities;
using BackEnd_DisciPlanner.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_DisciPlanner.Repositories.Implementations
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly DisciPlannerDbContext context;
        protected DbSet<T> dbSet;

        public BaseRepository(DisciPlannerDbContext dbContext)
        {
            this.context = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            var first = dbSet.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (first == null)
            {
                return false;
            }
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(dbSet.AsEnumerable());
        }

        public Task<T?> GetByIdAsync(int id)
        {
            return dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<T> UpdateAsync(T entity)
        {
            var first =
                dbSet.FirstOrDefaultAsync(e => e.Id == entity.Id)
                ?? throw new InvalidOperationException("Entity not found");
            dbSet.Update(entity);
            context.SaveChanges();
            return Task.FromResult(entity);
        }
    }
}
