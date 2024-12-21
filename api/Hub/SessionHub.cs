
using Microsoft.AspNetCore.SignalR;

public class SessionHub : Hub
{
    public async Task JoinSession(string sessionId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, sessionId);
        await Clients.Caller.SendAsync("ReceiveSession", sessionId);
    }

    public async Task LeaveSession(string sessionId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, sessionId);
    }

    public async Task UpdateSession(string sessionId)
    {
        await Clients.Group(sessionId).SendAsync("ReceiveScoreUpdate", sessionId);
    }

    public async Task SetEmdrState(string sessionId, string state)
    {
        await Clients.Group(sessionId).SendAsync("RecieveEmdrState", state);
    }

    public async Task SetSpeed(string sessionId, int speed)
    {
        await Clients.Group(sessionId).SendAsync("RecieveSpeed", speed);
    }
}
