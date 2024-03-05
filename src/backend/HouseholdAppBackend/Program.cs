using HouseholdAppBackend.SignalR;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddSingleton<InMemoryCache>();

var app = builder.Build();

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

// Configure the HTTP request pipeline.
app.UseCors("AllowLocalhost");

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF_API v1"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapHub<TaskHub>("task-hub");

app.Run();
