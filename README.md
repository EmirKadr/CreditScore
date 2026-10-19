# CreditScore

Ett Web API byggt med ASP.NET Core (Minimal APIs) som beräknar en kunds kreditvärdighet (0–100) utifrån årsinkomst och total skuld.

## Funktionalitet

- `GET /api/customers/{socialSecurityNumber}/credit-score` – returnerar kundens kreditvärde, eller `404 Not Found` om kunden inte finns.

## Teknik

- ASP.NET Core Web API (.NET 10)
- Dapper + SQL Server LocalDB/Express
- Interfaces och dependency injection (service och repository)
- Azure App Service (in-memory-repository i Azure)

## Kom igång

1. Skapa databasen genom att köra `CreditScore.Api/Data/CreateDatabase.sql`.
2. Sätt anslutningssträngen med User Secrets:
   ```
   dotnet user-secrets set "ConnectionStrings:Default" "Server=(localdb)\MSSQLLocalDB;Database=CreditScoreDb;Trusted_Connection=True;" --project CreditScore.Api
   ```
3. Kör applikationen:
   ```
   dotnet run --project CreditScore.Api
   ```
   HTTPS: `https://localhost:8000`, HTTP: `http://localhost:9000`
