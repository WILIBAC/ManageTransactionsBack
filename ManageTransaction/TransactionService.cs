using Microsoft.AspNetCore.SignalR;
using ReceiveApi.Data;
using System.Threading.Tasks;

public class TransactionService
{
    private readonly IHubContext<SignalRHub> _hubContext;
    private readonly AppDbContext _dbContext;

    public TransactionService(IHubContext<SignalRHub> hubContext, AppDbContext dbContext)
    {
        _hubContext = hubContext;
        _dbContext = dbContext;
    }

    public async Task PerformTransaction(string description, decimal amount)
    {
        var transaction = new Transaction
        {
            Description = description,
            Amount = amount,
            Date = DateTime.UtcNow
        };

        _dbContext.Transactions.Add(transaction);
        await _dbContext.SaveChangesAsync();

        //Console.WriteLine($"Sending transaction: {transaction.Description}, {transaction.Amount}"); // Depuración

        await _hubContext.Clients.All.SendAsync("ReceiveTransaction", transaction.Description, transaction.Amount);
    }
}

