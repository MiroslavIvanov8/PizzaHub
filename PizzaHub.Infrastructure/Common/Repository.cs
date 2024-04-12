using Microsoft.EntityFrameworkCore;

namespace PizzaHub.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(PizzaHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await this.DbSet<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entity) where T : class
        {
            await this.dbContext.AddRangeAsync(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().RemoveRange(entities);
            await SaveChangesAsync();
        }

        public async Task<bool> Remove<T>(T entity) where T : class
        {
            try
            {
                DbSet<T>().Remove(entity);

                await SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                
                return false; 
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }
}
