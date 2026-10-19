using CreditScore.Api.Models;
using CreditScore.Api.Repositories;

namespace CreditScore.Api.Services;

public class CreditScoreService(ICustomerRepository customerRepository) : ICreditScoreService
{
    private const int MinCreditScore = 0;
    private const int MaxCreditScore = 100;

    public async Task<int?> GetCreditScoreAsync(string socialSecurityNumber)
    {
        var customer = await customerRepository.GetBySocialSecurityNumberAsync(socialSecurityNumber);

        return customer is null ? null : CalculateCreditScore(customer);
    }

    private static int CalculateCreditScore(Customer customer)
    {
        // Kund utan årsinkomst får 0 poäng (och vi undviker division med 0)
        if (customer.AnnualIncome <= 0)
            return MinCreditScore;

        var creditScore = MaxCreditScore - (customer.TotalDebt / customer.AnnualIncome * MaxCreditScore);

        return (int)Math.Clamp(Math.Round(creditScore, MidpointRounding.AwayFromZero), MinCreditScore, MaxCreditScore);
    }
}
