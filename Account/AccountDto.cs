using TransAccount.Transactions;
using TransAccount.User;

namespace TransAccount.Account
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public int Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public int CurrencyId { get; set; }
        public List<TransactionDto>? Transactions { get; set; }
        public UserDto User { get; set; }
    }
}
