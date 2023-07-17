using Bank.Domain.Concrete;
using Bank.Domain.Repositories;
using Bank.Persistence.Contexts.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BankContext context) : base(context)
        {

        }
    }
}
