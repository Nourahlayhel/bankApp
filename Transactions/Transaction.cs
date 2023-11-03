using TransAccount.Database;

namespace TransAccount.Transactions
{
    public class Transaction
    {
        private readonly int transactionId;
        private readonly int amount;
        private readonly int accountId;
        private readonly int transactionTypeId;
        private readonly DateTime transactionDate;

        public Transaction(int transactionId, int amount, int accountId, int transactionTypeId, DateTime transactionDate)
        {
            this.transactionId = transactionId;
            this.amount = amount;
            this.accountId = accountId;
            this.transactionTypeId = transactionTypeId;
            this.transactionDate = transactionDate;
        }
        public Transaction(DbTransaction dbTransaction): this(dbTransaction.TransactionID, dbTransaction.Amount, dbTransaction.AccountID, dbTransaction.TypeID, dbTransaction.TransactionDate) 
        { }

        public virtual DbTransaction toDb()
        {
            return new DbTransaction()
            {
                TransactionID = transactionId,
                AccountID = accountId,
                Amount = amount,
                TransactionDate = transactionDate,
                TypeID = transactionTypeId,
            };
        }
    }
}
