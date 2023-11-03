using TransAccount.Database;

namespace TransAccount.Account
{
    public class Account
    {
        private readonly int accountId;
        private readonly int customerId;
        private readonly int currencyId;
        private int balance;
        private DateTime creationDate;

        public Account(int accountId, int balance, int customerId, int currencyId, DateTime creationDate)
        {
            this.accountId = accountId;
            this.balance = balance;
            this.customerId = customerId;
            this.currencyId = currencyId;
            this.creationDate = creationDate;
        }
        public Account(DbAccount dbAccount) : this(dbAccount.AccountID, dbAccount.Balance, dbAccount.CustomerId, dbAccount.CurrencyId, dbAccount.CreationDate)
        {
        }
        public int Balance => this.balance;
        public int CustomerId => this.customerId;
        public virtual AccountDto ToDtoModel()
        {
            return new()
            {
                AccountId = accountId,
                Balance = balance,
                CustomerId = customerId,
                CreationDate = creationDate,
                CurrencyId = currencyId,
            };
        }
        public DbAccount toDb()
        {
            return new DbAccount()
            {
                AccountID = accountId,
                Balance = balance,
                CustomerId = customerId,
                CreationDate = creationDate,
                CurrencyId = currencyId,
            };
        }
        public void SetCreatedDate(DateTime date)
        {
            this.creationDate = date;
        }
        public void SetBalance(int balance)
        {
            this.balance = balance;
        }

        public virtual DbAccount UpdateDb(DbAccount account)
        {
            account.Balance = balance;
            return account;
        }
    }
}
