using Bank.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Concrete
{
    public class Customer : BaseInfo
    {
        public DateTime BirtDate { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public int IdentityNumber { get; set; }
        public string Address { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
