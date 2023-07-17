using Bank.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Concrete
{
    public class Account : BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
