# Camp Booking API

This repository contains an ASP.NET 6 Web API for managing camps and customers in a booking system.
The API now uses Entity Framework Core with SQL Server for persistence.
The default connection string is stored in `appsettings.json`:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=AKASHJATWA\\SQLEXPRESS;Database=MyApplicationDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## Running the project

1. Install the .NET 6 SDK.
2. Navigate to the API directory and run the application:

```bash
cd CampBookingApi
dotnet run
```

The API exposes controller-based endpoints to manage camps and customers. You can create, update, or delete camp and customer records through the corresponding `/api/camps` and `/api/customers` endpoints.
