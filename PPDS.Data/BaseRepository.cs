using Microsoft.EntityFrameworkCore;
using PPDS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Data
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public Task DeleteAsync(object Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(params object[] Id) => await dbSet.FindAsync(Id);

        public async Task InsertAsync(T entity)
        {
            dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task InsertAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
