using System.Text.RegularExpressions;

namespace CreditScore.Api.Validators;

public static partial class CustomerValidator
{
    // Format: YYYYMMDD-XXXX
    [GeneratedRegex(@"^\d{8}-\d{4}$")]
    private static partial Regex SocialSecurityNumberPattern();

    public static void ValidateNewCustomer(string? socialSecurityNumber, string? name, decimal annualIncome, decimal totalDebt)
    {
        if (string.IsNullOrWhiteSpace(socialSecurityNumber) || !SocialSecurityNumberPattern().IsMatch(socialSecurityNumber))
            throw new ArgumentException("Personnummer måste ha formatet YYYYMMDD-XXXX.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Namn måste anges.");

        ValidateFinances(annualIncome, totalDebt);
    }

    public static void ValidateFinances(decimal annualIncome, decimal totalDebt)
    {
        if (annualIncome < 0)
            throw new ArgumentException("Årsinkomsten får inte vara negativ.");

        if (totalDebt < 0)
            throw new ArgumentException("Den totala skulden får inte vara negativ.");
    }
}
