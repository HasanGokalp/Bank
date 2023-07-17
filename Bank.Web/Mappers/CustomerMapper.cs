using AutoMapper;
using Bank.Domain.DTOs;
using Bank.Web.Models;

namespace Bank.Web.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper() 
        { 
            CreateMap<CustomerVM, CustomerDTO>();
            CreateMap<CustomerDTO, CustomerVM>();
        }
    }
}
