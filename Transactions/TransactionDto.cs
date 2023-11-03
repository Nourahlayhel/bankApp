namespace TransAccount.Transactions
{
    public class TransactionDto
    {
        public int Amount { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public int AccountId { get; set; }
    }
}
