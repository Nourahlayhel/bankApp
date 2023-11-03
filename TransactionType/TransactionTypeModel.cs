using TransAccount.Database;

namespace TransAccount.TransactionType
{
    public class TransactionTypeModel
    {
        private readonly int transactionTypeId;
        private readonly string name;
        private readonly string? description;

        public TransactionTypeModel(int transactionTypeId, string name, string description)
        {
            this.transactionTypeId = transactionTypeId;
            this.name = name;
            this.description = description;
        }
        public TransactionTypeModel(DbTransactionType dbTransactionType) : this(dbTransactionType.TransactionTypeID, dbTransactionType.Name.ToString(), dbTransactionType.Description)
        { }
        public TransactionTypeDto toDto()
        {
            return new TransactionTypeDto()
            {
                TransactionTypeId = this.transactionTypeId,
                Name = this.name,
                Description = this.description,
            };
        }
    }
}
