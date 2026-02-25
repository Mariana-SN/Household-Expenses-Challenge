using HouseholdExpenses.Application.DTOs;
using HouseholdExpenses.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesAPI.Controllers
{
    /// <summary>
    /// Endpoint principal para movimentações financeiras e relatórios.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Registra uma nova transação financeira.
        /// Captura erros de validação (como menores de idade tentando registrar receitas).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionRequest request)
        {
            try
            {
                var result = await _transactionService.CreateTransactionAsync(request);
                return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary> Lista o histórico de todas as transações com detalhes. </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        /// <summary> Gera o balanço financeiro detalhado e global. </summary>
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var summary = await _transactionService.GetFinancialSummaryAsync();
            return Ok(summary);
        }
    }
}
