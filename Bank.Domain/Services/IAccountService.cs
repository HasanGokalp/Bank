using Bank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAllCategories();

        void AddCategory(AccountDTO accountDTO);

        AccountDTO GetCategoryById(string accountId);

        void UpdateCategory(AccountDTO accountDTO);

        void DeleteCategory(string accountId);
    }
}
