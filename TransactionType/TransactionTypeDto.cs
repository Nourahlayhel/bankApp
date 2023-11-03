namespace TransAccount.TransactionType
{
    public class TransactionTypeDto
    {
        public int TransactionTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
