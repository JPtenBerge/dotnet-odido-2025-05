using Microsoft.EntityFrameworkCore;
using Odido.BusinessLogic.Interfaces;
using Odido.BusinessLogic.Services;
using Odido.DataLayer.Data;
using Odido.DataLayer.Interfaces;
using Odido.DataLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRepository, EfGameRepository>();
builder.Services.AddDbContext<OdidoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Create database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OdidoDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
