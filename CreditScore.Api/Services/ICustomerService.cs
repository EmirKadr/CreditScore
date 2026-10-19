using CreditScore.Api.Models;

namespace CreditScore.Api.Services;

public interface ICustomerService
{
    // Returnerar null om kunden redan finns. Kastar ArgumentException vid ogiltig data.
    Task<Customer?> CreateCustomerAsync(string socialSecurityNumber, string name, decimal annualIncome, decimal totalDebt);

    // Returnerar null om kunden inte finns. Kastar ArgumentException vid ogiltig data.
    Task<Customer?> UpdateCustomerFinancesAsync(string socialSecurityNumber, decimal annualIncome, decimal totalDebt);
}
