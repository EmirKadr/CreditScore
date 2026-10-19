using CreditScore.Api.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CreditScore.Api.Repositories;

public class CustomerRepository(IConfiguration configuration) : ICustomerRepository
{
    private readonly string _connectionString = configuration.GetConnectionString("Default")
        ?? throw new InvalidOperationException("Anslutningssträngen 'Default' saknas.");

    public async Task<Customer?> GetBySocialSecurityNumberAsync(string socialSecurityNumber)
    {
        const string sql = """
            SELECT Id, SocialSecurityNumber, Name, AnnualIncome, TotalDebt
            FROM dbo.Customers
            WHERE SocialSecurityNumber = @SocialSecurityNumber;
            """;

        using var connection = new SqlConnection(_connectionString);

        return await connection.QuerySingleOrDefaultAsync<Customer>(sql, new { SocialSecurityNumber = socialSecurityNumber });
    }
}
