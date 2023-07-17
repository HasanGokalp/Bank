using Bank.Domain.Repositories;
using Bank.Persistence.Contexts.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private bool disposedValue;
        private DbSet<TEntity> Table;
        private BankContext Context;

        public BaseRepository(BankContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Table;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter = null)
        {
            return Table.Where(filter);
        }

        public async Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter = null)
        {
           return await Table.Where(filter).ToListAsync();
        }

        public TEntity GetById(int id)
        {
            var entity = Table.Find(id);
            if (entity == null)
            {
                throw new InvalidOperationException("İd bulunamadı");
            }
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException("İd bulunamadı");
            }
            return entity;
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Table.SingleOrDefaultAsync(filter);
        }

        public void Insert(TEntity entity)
        {
            Table.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            Table.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            Table.Update(entity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: yönetilen durumu (yönetilen nesneleri) atın
                }

                // TODO: yönetilmeyen kaynakları (yönetilmeyen nesneleri) serbest bırakın ve sonlandırıcıyı geçersiz kılın
                // TODO: büyük alanları null olarak ayarlayın
                disposedValue = true;
            }
        }

        // // TODO: sonlandırıcıyı yalnızca 'Dispose(bool disposing)' içinde yönetilmeyen kaynakları serbest bırakacak kod varsa geçersiz kılın
        // ~BaseRepository()
        // {
        //     // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
