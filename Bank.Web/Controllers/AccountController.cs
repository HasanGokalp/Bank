using AutoMapper;
using Bank.Domain.DTOs;
using Bank.Domain.Services;
using Bank.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Account/List")]
        public async Task<IActionResult> List()
        {
            var accounts = await _accountService.GetAllCategories();
            var accountVMs = _mapper.Map<IEnumerable<AccountDTO>, IEnumerable<AccountVM>>(accounts);
            return View(accountVMs);
        }
    }
}
