using TransAccount.Database;
using TransAccount.Transactions;
using TransAccount.User;

namespace TransAccount.Account
{
    public class AccountService
    {
        private IAccountRepository accountRepository;
        private TransactionsService transactionsService;

        public AccountService(IAccountRepository accountRepository, TransactionsService transactionsService)
        {
            this.accountRepository = accountRepository;
            this.transactionsService = transactionsService;
        }

        public async Task<AccountDto> CreateAccount(CreateAccountDto createAccountDto)
        {
            Account account = new (0, 0, createAccountDto.CustomerId, createAccountDto.CurrencyId, DateTime.Now);
            DbAccount createdAccount = await this.accountRepository.CreateAccount(account);
            AccountDto accountDto = new Account(createdAccount).ToDtoModel();
            accountDto.Balance = createAccountDto.InitialCredit;
            if(createAccountDto.InitialCredit != 0)
            {
                var transaction = await this.transactionsService.AddDepositTransactionToNewAccount(createdAccount, createAccountDto.InitialCredit);
                accountDto.Transactions = new() { transaction };
            }
            return accountDto;
        }

        public async Task<List<AccountDto>> GetAccountsForUser(int userId)
        {
            var accounts = await this.accountRepository.GetAccountsForUser(userId);
            return accounts.Select(acc => new AccountDto()
            {
                AccountId = acc.AccountID,
                Transactions = acc.Transactions.Select(t => new Transactions.TransactionDto() { Amount = t.Amount, TransactionType = t.TransactionType.Name.ToString(), TransactionDate = t.TransactionDate }).ToList(),
                User = new UserModel(acc.User).toDtoModel(),
                CurrencyId = acc.CurrencyId,
                Balance = acc.Balance,
            }).ToList();

        }
    }
}
