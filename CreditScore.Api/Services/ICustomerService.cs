using CreditScore.Api.Models;

namespace CreditScore.Api.Services;

public interface ICustomerService
{
    // Returnerar null om kunden redan finns. Kastar ArgumentException vid ogiltig data.
    Task<Customer?> CreateCustomerAsync(string socialSecurityNumber, string name, decimal annualIncome, decimal totalDebt);
}
