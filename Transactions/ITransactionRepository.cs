using TransAccount.TransactionType;

namespace TransAccount.Transactions
{
    public interface ITransactionRepository
    {
        Task ExecuteTransaction(Transaction transaction);
        Task<List<TransactionTypeModel>> GetTransactionTypes();
        Task<int?> GetTransactionTypeIdByName(Database.TransactionType name);
    }
}
