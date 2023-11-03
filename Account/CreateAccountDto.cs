namespace TransAccount.Account
{
    public class CreateAccountDto
    {
        public int CustomerId { get; set; }
        public int InitialCredit { get; set; }
        public int CurrencyId { get; set; }
    }
}
