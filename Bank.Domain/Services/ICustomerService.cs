using Bank.Domain.Concrete;
using Bank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCategories();

        void AddCategory(CustomerDTO customerDTO);

        CustomerDTO GetCategoryById(string customerId);

        void UpdateCategory(CustomerDTO customerDTO);

        void DeleteCategory(string customerId);
        
    }
}
