using PPDS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {

        Task<TEntity> GetByIdAsync(params object[] Id);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(object Id);

        Task DeleteAsync(TEntity entity);

        Task InsertAsync(TEntity entity);

        Task InsertAsync(IEnumerable<TEntity> entities);

        
    }
}
