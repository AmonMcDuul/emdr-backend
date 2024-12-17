
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

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
}
