using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface IRepository<TEntity>:IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
