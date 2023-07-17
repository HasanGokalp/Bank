using AutoMapper;
using Bank.Domain.DTOs;
using Bank.Web.Models;

namespace Bank.Web.Mappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper() 
        {
            CreateMap<AccountVM, AccountDTO>();
            CreateMap<AccountDTO, AccountVM>();
        }
    }
}
