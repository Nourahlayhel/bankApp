using TransAccount.Account;
using TransAccount.Database;
using TransAccount.TransactionType;

namespace TransAccount.Transactions
{
    public class TransactionsService
    {
        private ITransactionRepository transactionsRepository;
        private IAccountRepository accountRepository;

        public TransactionsService(ITransactionRepository transacrionsRepository, IAccountRepository accountRepository)
        {
            this.transactionsRepository = transacrionsRepository;
            this.accountRepository = accountRepository;
        }

        public async Task<TransactionDto> AddDepositTransactionToNewAccount(DbAccount createdAccount, int deposit)
        {
            TransactionDto transactionDto = new ()
            {
                AccountId = createdAccount.AccountID,
                Amount = deposit,
                TransactionType = Database.TransactionType.Deposit.ToString(),
                TransactionTypeId = await this.transactionsRepository.GetTransactionTypeIdByName(Database.TransactionType.Deposit),
            };
            await this.ExecuteTransactionOnAccount(createdAccount, transactionDto);
            return transactionDto;
        }
        public async Task ExecuteTransaction(TransactionDto transactionDto)
        {
            var account = await this.accountRepository.GetAccountById(transactionDto.AccountId);
            await this.ExecuteTransactionOnAccount(account, transactionDto);
            
        }

        public async Task ExecuteTransactionOnAccount(DbAccount account, TransactionDto transactionDto)
        {
            Transaction trans = new(0, transactionDto.Amount, transactionDto.AccountId, transactionDto.TransactionTypeId, DateTime.Now);
            await this.transactionsRepository.ExecuteTransaction(trans);
            var currentBalance = account.Balance;
            if(transactionDto.TransactionType == Database.TransactionType.Deposit.ToString())
            {
                currentBalance += transactionDto.Amount;
            }
            else
            {
                currentBalance -= transactionDto.Amount;
            }
            await this.accountRepository.UpdateAccountBalance(account, currentBalance);
        }
        public async Task<List<TransactionTypeDto>> GetTransactionTypes()
        {
            return (await this.transactionsRepository.GetTransactionTypes()).Select(t => t.toDto()).ToList();
        }
    }
}
