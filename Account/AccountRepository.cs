using Microsoft.EntityFrameworkCore;
using TransAccount.Database;
using TransAccount.User;

namespace TransAccount.Account
{
    public class AccountRepository : IAccountRepository
    {
        private TransAccContext context;

        public AccountRepository(TransAccContext context)
        {
            this.context = context;
        }

        public async Task<DbAccount> CreateAccount(Account account)
        {
            DbAccount dbAccount = account.toDb();
            await this.context.Accounts.AddAsync(dbAccount);
            await this.context.SaveChangesAsync();
            return dbAccount;
        }
        public async Task<DbAccount?> GetAccountById(int id)
        {
            return await context.Accounts.Where(acc => acc.AccountID == id).SingleAsync();
        }

        public async Task<List<DbAccount>> GetAccountsForUser(int customerId)
        {
            return await this.context.Accounts.Where(acc => acc.CustomerId == customerId).OrderByDescending(acc => acc.AccountID).Include(acc => acc.User).Include(acc => acc.Transactions).ThenInclude(t => t.TransactionType).ToListAsync();        
        }
        
        public async Task UpdateAccountBalance(DbAccount account, int balance)
        {
            var accountModel = new Account(account);
            accountModel.SetBalance(balance);
            accountModel.UpdateDb(account);
            await this.context.SaveChangesAsync();
        }
    }
}
