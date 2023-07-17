using AutoMapper;
using Bank.Domain.Concrete;
using Bank.Domain.DTOs;
using Bank.Domain.Repositories;
using Bank.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.Services
{
    public class CustomerService : ICustomerService
    {
        protected readonly IUnitWork Database;
        protected readonly IMapper Mapper;

        public CustomerService(IUnitWork database, IMapper mapper) 
        {
            Database = database;
            Mapper = mapper;
        }
        public void AddCategory(CustomerDTO CustomerDTO)
        {
            var entity = Mapper.Map<CustomerDTO, Customer>(CustomerDTO);
            Database.CustomerRepository.Insert(entity);
            Database.Commit();
        }

        public void DeleteCategory(string CustomerId)
        {
            var entity = Database.CustomerRepository.GetById(int.Parse(CustomerId));
            if (entity != null)
            {
                Database.CustomerRepository.Delete(entity);
            }
            else
            {
                throw new Exception("Böyle bir id de data bulunamadı");
            }
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCategories()
        {
            var entities = await Database.CustomerRepository.GetAllAsync();
            var Customers = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(entities);
            return Customers;
        }

        public CustomerDTO GetCategoryById(string CustomerId)
        {
            var entity = Database.CustomerRepository.GetById(int.Parse(CustomerId));
            var map = Mapper.Map<CustomerDTO>(entity);
            return map;
        }

        public void UpdateCategory(CustomerDTO CustomerDTO)
        {
            var entity = Mapper.Map<CustomerDTO, Customer>(CustomerDTO);
            Database.CustomerRepository.Update(entity);
        }
    }
}
