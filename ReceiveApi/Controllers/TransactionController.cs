using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteTransaction([FromBody] TransactionRequest request)
    {
        await _transactionService.PerformTransaction(request.Description, request.Amount);
        return Ok();
    }
}

public class TransactionRequest
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
