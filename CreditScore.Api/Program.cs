using CreditScore.Api.DTOs;
using CreditScore.Api.Repositories;
using CreditScore.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICreditScoreService, CreditScoreService>();

// Lokalt (Development): SQL Server. I Azure: in-memory, Singleton så att datan lever mellan anrop.
if (builder.Environment.IsDevelopment())
    builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
else
    builder.Services.AddSingleton<ICustomerRepository, MockCustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/customers/{socialSecurityNumber}/credit-score", async (string socialSecurityNumber, ICreditScoreService creditScoreService) =>
{
    var creditScore = await creditScoreService.GetCreditScoreAsync(socialSecurityNumber);

    return creditScore is null
        ? Results.NotFound(new { error = $"Kunden med personnummer {socialSecurityNumber} finns inte." })
        : Results.Ok(new CreditScoreResponse(socialSecurityNumber, creditScore.Value));
});

app.Run();
