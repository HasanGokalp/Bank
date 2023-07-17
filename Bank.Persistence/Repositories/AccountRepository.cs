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
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(BankContext context) : base(context)
        {

        }
    }
}
