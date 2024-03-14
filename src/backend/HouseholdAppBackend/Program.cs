using HouseholdAppBackend.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddSingleton<InMemoryCache>();

var app = builder.Build();
app.MapHub<TaskHub>("task-hub");
app.Run();
