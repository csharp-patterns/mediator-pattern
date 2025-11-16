using Scalar.AspNetCore;
using MediatorPattern.Repo;
using MediatorPattern.Domains;
using MediatorPattern.API.AppStart;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var configuration = builder.Configuration;

// setup dependency injections
builder.Services.AddDIRegistrations(configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// seed a small set of customers so services can observe data immediately.
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<EFDbContext>();
    if (!ctx.Customers.Any())
    {
        ctx.Customers.AddRange(
            new CustomerDb { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new CustomerDb { Id = 2, Name = "Bob", Email = "bob@example.com" }
        );
        ctx.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();   // exposes https://localhost:7046/openapi/v1.json

    app.MapScalarApiReference(opt =>
    {
        opt.Title = "Mediator Pattern API";
    });                 // exposes https://localhost:7046/scalar
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
