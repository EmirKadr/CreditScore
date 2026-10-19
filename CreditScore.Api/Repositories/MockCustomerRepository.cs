using CreditScore.Api.Models;

namespace CreditScore.Api.Repositories;

// Lagrar kunduppgifter i minnet. Datan försvinner när applikationen startas om.
public class MockCustomerRepository : ICustomerRepository
{
    private readonly Dictionary<string, Customer> _customers = new(StringComparer.Ordinal)
    {
        ["19900101-2010"] = new() { Id = 1, SocialSecurityNumber = "19900101-2010", Name = "Anna Svensson", AnnualIncome = 520000, TotalDebt = 150000 },
        ["19850515-1234"] = new() { Id = 2, SocialSecurityNumber = "19850515-1234", Name = "Erik Johansson", AnnualIncome = 360000, TotalDebt = 180000 },
        ["19780320-5678"] = new() { Id = 3, SocialSecurityNumber = "19780320-5678", Name = "Maria Lindberg", AnnualIncome = 680000, TotalDebt = 1200000 }
    };

    public Task<Customer?> GetBySocialSecurityNumberAsync(string socialSecurityNumber) =>
        Task.FromResult(_customers.GetValueOrDefault(socialSecurityNumber));
}
