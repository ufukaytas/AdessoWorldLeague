using Microsoft.Extensions.DependencyInjection;
using AdessoWorldLeague.Application;
using AdessoWorldLeague.Infrastructure;
using AdessoWorldLeague.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // <-- BUNU EKLE!
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // <-- BUNU EKLE!

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AdessoDbContext>();
    await SeedData.EnsureSeededAsync(dbContext);
}

app.Run();