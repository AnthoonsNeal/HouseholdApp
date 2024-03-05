using Microsoft.AspNetCore.SignalR;

namespace HouseholdAppBackend.SignalR;

public class TaskHub : Hub
{
    private readonly InMemoryCache _inMemoryCache;

    public TaskHub(InMemoryCache inMemoryCache) => _inMemoryCache = inMemoryCache;

    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("ReceivedMessage", _inMemoryCache.Entries.ToJson());
        await base.OnConnectedAsync();
    }
	
    public async Task AddReminder(string text)
    {
        var reminder = _inMemoryCache.Add(text);
        await Clients.All.SendAsync("AddedMessage", reminder.ToJson());
    }
}