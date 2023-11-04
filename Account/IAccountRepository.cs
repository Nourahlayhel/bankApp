using TransAccount.Database;

namespace TransAccount.Account
{
    public interface IAccountRepository
    {
        Task<DbAccount> CreateAccount(Account account);
        Task<List<DbAccount>> GetAccountsForUser(int customerId);
        Task<DbAccount?> GetAccountById(int id);
        Task UpdateAccountBalance(DbAccount account, int balance);
    }
}
