using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransAccount.TransactionType;

namespace TransAccount.Transactions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private TransactionsService transactionsService;

        public TransactionsController(TransactionsService transactionsService)
        {
            this.transactionsService = transactionsService;
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<TransactionTypeDto>>> GetTransactionTypes()
        {
            var types = await this.transactionsService.GetTransactionTypes();
            return this.Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteTransaction(TransactionDto transactionDto)
        {
            await this.transactionsService.ExecuteTransaction(transactionDto);
            return this.Ok();
        }
    }
}
