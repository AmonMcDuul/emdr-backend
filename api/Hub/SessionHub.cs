
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

    public async Task SetEmdrState(string sessionId, string state)
    {
        await Clients.Group(sessionId).SendAsync("RecieveEmdrState", state);
    }

    public async Task SetSpeed(string sessionId, int speed)
    {
        await Clients.Group(sessionId).SendAsync("RecieveSpeed", speed);
    }

    public async Task ToggleSound(string sessionId, bool enableSound)
    {
        await Clients.Group(sessionId).SendAsync("RecieveToggleSound", enableSound);
    }

    public async Task ToggleDistraction(string sessionId, bool enableDistraction)
    {
        await Clients.Group(sessionId).SendAsync("RecieveToggleDistraction", enableDistraction);
    }

    //public async Task SetVideo(string sessionId, string videoUrl)
    //{
    //    await Clients.Group(sessionId).SendAsync("RecieveSetVideo", videoUrl);
    //}

    //public async Task ToggleVideo(string sessionId, bool enableVideo)
    //{
    //    await Clients.Group(sessionId).SendAsync("RecieveToggleVideo", enableVideo);
    //}
}
