using AutoMapper;
using Bank.Domain.Concrete;
using Bank.Domain.DTOs;
using Bank.Domain.Repositories;
using Bank.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.Services
{
    public class AccountService : IAccountService
    {
        protected readonly IUnitWork Database;
        protected readonly IMapper Mapper;
        public AccountService(IUnitWork database, IMapper mapper) 
        {
            Database = database;
            Mapper = mapper;
        }

        public void AddCategory(AccountDTO accountDTO)
        {
            var entity = Mapper.Map<AccountDTO, Account>(accountDTO);
            Database.AccountRepository.Insert(entity);
            Database.Commit();
        }

        public void DeleteCategory(string accountId)
        {
            var entity = Database.AccountRepository.GetById(int.Parse(accountId));
            if (entity != null)
            {
                Database.AccountRepository.Delete(entity);
            }
            else
            {
                throw new Exception("Böyle bir id de data bulunamadı");
            }
            Database.Commit();
        }

        public async Task<IEnumerable<AccountDTO>> GetAllCategories()
        {
            var entities = await Database.AccountRepository.GetAllAsync();
            var accounts = Mapper.Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(entities);
            return accounts;
        }

        public AccountDTO GetCategoryById(string accountId)
        {
            var entity = Database.AccountRepository.GetById(int.Parse(accountId));
            var map = Mapper.Map<AccountDTO>(entity);
            return map;
        }

        public void UpdateCategory(AccountDTO accountDTO)
        {
            var entity = Mapper.Map<AccountDTO, Account>(accountDTO);
            Database.AccountRepository.Update(entity);
            Database.Commit();
        }
    }
}
