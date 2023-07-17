using Bank.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Services
{
    public interface IUnitWork
    {
        ICustomerRepository CustomerRepository { get; }
        IAccountRepository AccountRepository { get; }
        bool Commit();
        Task<bool> CommitAsync();
    }
}
