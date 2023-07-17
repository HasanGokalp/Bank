using Bank.Domain.Repositories;
using Bank.Domain.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Persistence.Contexts.EFCore;
using Bank.Domain.Abstract;

namespace Bank.Persistence
{
    public class UnitWork : IUnitWork
    {
        public BankContext Context { get; }
        public ICustomerRepository CustomerRepository { get; }

        public IAccountRepository AccountRepository { get; }

        public UnitWork(ICustomerRepository customerRepository, IAccountRepository accountRepository, BankContext context)
        {
            CustomerRepository = customerRepository;
            AccountRepository = accountRepository;
            Context = context;
        }
        void HandleCrudOperationsLog()
        {
            var entries = Context.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    Console.WriteLine("değiştirildi");
                }
                if (entry.State == EntityState.Deleted || entry.State == EntityState.Modified)
                {
                    Console.WriteLine("değiştirildi");
                }
            } 
        }


        /// <summary>
        /// Herhangi bir entity üzerinde insert veya update işlemleri yapıldığında CreateDate, LastupDate, 
        /// CreateUser ve LastupUser bilgilerini otomatik olarak güncelleyen metodumuz
        /// </summary>

        void UpdateEntityCrudInformation()
        {
            var entries = Context.ChangeTracker.Entries();

            var trackableEntries = entries.Where(entry => entry.Entity is BaseInfo);

            foreach (var entry in trackableEntries)
            {
                var entity = entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    Console.WriteLine("değiştirildi");
                }
                else if (entry.State == EntityState.Modified)
                {
                    Console.WriteLine("değiştirildi");
                }
            }
        }


        /// <summary>
        /// Herhangi bir entity için onun güncel durumunu getirir.
        /// </summary>
        /// <param name="entry">ChangeTracker üzerinden elde edilen her bir EntityEntry değerini tanımlamaktadır</param>
        /// <returns></returns>

        private object GetCurrentValues(EntityEntry entry)
        {
            return entry.Entity;
        }

        /// <summary>
        /// Herhangi bir entity için onun önceki durumunu getirir.
        /// </summary>
        /// <param name="entry">ChangeTracker üzerinden elde edilen her bir EntityEntry değerini tanımlamaktadır</param>
        /// <returns></returns>

        private object GetOldValues(EntityEntry entry)
        {
            var entityType = entry.Entity.GetType();
            var entity = Activator.CreateInstance(entityType);

            foreach (var prop in entry.Properties)
            {
                var propertyValue = entry.GetDatabaseValues().GetValue<object>(prop.Metadata.Name);
                var entityProperty = entityType.GetProperty(prop.Metadata.Name);
                entityProperty.SetValue(entity, propertyValue);
            }
            return entity;
        }


        public bool Commit()
        {
            int numRows = 0;
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    //Crud Operations Log
                    HandleCrudOperationsLog();

                    //Trackable Entity'lerin CreateDate, LastupDate, CreateUser ve LastupUser gibi bilgileri
                    //otomatik olarak ayarlanıyor.
                    UpdateEntityCrudInformation();

                    numRows = Context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Context.ChangeTracker.Clear();
                    throw ex;
                }
            }
            return numRows != 0;
        }


        public async Task<bool> CommitAsync()
        {
            int numRows = 0;
            using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                try
                {
                    //Crud Operations Log
                    HandleCrudOperationsLog();

                    //Trackable Entity'lerin CreateDate, LastupDate, CreateUser ve LastupUser gibi bilgileri
                    //otomatik olarak ayarlanıyor.
                    UpdateEntityCrudInformation();

                    numRows = await Context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Context.ChangeTracker.Clear();
                    throw ex;
                }
            }
            return numRows != 0;
        }



        bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    CustomerRepository.Dispose();
                    AccountRepository.Dispose();
                    Context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

