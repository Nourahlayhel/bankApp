using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TransAccount.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountService service;
        public AccountController(AccountService service)
        {
            this.service = service;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<AccountDto>>> GetAccountsOfUser(int userId)
        {
            var accounts = await this.service.GetAccountsForUser(userId);
            return this.Ok(accounts);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> CreateAccount(CreateAccountDto createAccountDto)
        {
            AccountDto account = await this.service.CreateAccount(createAccountDto);
            return this.Ok(account);
        }
    }
}
