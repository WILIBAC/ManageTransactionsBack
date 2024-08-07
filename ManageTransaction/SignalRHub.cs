using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class SignalRHub : Hub
{
    public async Task SendMessage(string description, decimal amount)
    {
        // Envía el mensaje a todos los clientes conectados
        await Clients.All.SendAsync("ReceiveMessage", description, amount);
    }
}

