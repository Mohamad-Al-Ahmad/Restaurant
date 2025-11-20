using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionStrings = builder.Configuration.GetConnectionString("Constr");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionStrings));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

