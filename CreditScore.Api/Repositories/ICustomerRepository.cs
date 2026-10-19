using CreditScore.Api.Models;

namespace CreditScore.Api.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetBySocialSecurityNumberAsync(string socialSecurityNumber);

    // Returnerar null om en kund med samma personnummer redan finns
    Task<Customer?> CreateAsync(Customer customer);
}
