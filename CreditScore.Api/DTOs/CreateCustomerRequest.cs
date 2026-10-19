namespace CreditScore.Api.DTOs;

public record CreateCustomerRequest(string SocialSecurityNumber, string Name, decimal AnnualIncome, decimal TotalDebt);
