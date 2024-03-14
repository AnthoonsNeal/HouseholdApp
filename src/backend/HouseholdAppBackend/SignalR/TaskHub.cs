using Microsoft.AspNetCore.SignalR;

namespace HouseholdAppBackend.SignalR;

public class TaskHub(ILogger<TaskHub> logger, InMemoryCache inMemoryCache) : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("ReceivedMessage", inMemoryCache.Entries.ToJson());
        logger.LogInformation("Client connected");
        await base.OnConnectedAsync();
    }
	
    public async Task AddReminder(string text)
    {
        var reminder = inMemoryCache.Add(text);
        await Clients.All.SendAsync("AddedMessage", reminder.ToJson());
        logger.LogInformation($"Added reminder {text}");
    }
}