using CreditScore.Api.Models;
using CreditScore.Api.Repositories;
using CreditScore.Api.Validators;

namespace CreditScore.Api.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public async Task<Customer?> CreateCustomerAsync(string socialSecurityNumber, string name, decimal annualIncome, decimal totalDebt)
    {
        CustomerValidator.ValidateNewCustomer(socialSecurityNumber, name, annualIncome, totalDebt);

        return await customerRepository.CreateAsync(new Customer
        {
            SocialSecurityNumber = socialSecurityNumber,
            Name = name.Trim(),
            AnnualIncome = annualIncome,
            TotalDebt = totalDebt
        });
    }
}
