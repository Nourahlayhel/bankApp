using Microsoft.EntityFrameworkCore;
using TransAccount.Database;
using TransAccount.TransactionType;

namespace TransAccount.Transactions
{
    public class TransactionsRepository : ITransactionRepository
    {
        private TransAccContext context;

        public TransactionsRepository(TransAccContext context)
        {
            this.context = context;
        }

        public async Task ExecuteTransaction(Transaction transaction)
        {
            DbTransaction dbTransaction = transaction.toDb();
            await this.context.Transactions.AddAsync(dbTransaction);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<TransactionTypeModel>> GetTransactionTypes() 
        {
            var types = await this.context.TransactionTypes.ToListAsync();
            return types.Select(t => new TransactionTypeModel(t)).ToList();
        }

        public async Task<int> GetTransactionTypeIdByName(Database.TransactionType name)
        {
            return await this.context.TransactionTypes.Where(t => t.Name == name).Select(t => t.TransactionTypeID).SingleAsync();
        }
    }
}
