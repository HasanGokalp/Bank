using AutoMapper;
using Bank.Domain.Concrete;
using Bank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper() {

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
