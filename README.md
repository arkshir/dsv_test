# Movies API

![image](https://github.com/user-attachments/assets/97832997-c0ab-499f-81f9-55c2779e26e7)

![image](https://github.com/user-attachments/assets/3a7eafe6-97db-4bea-9aa8-be11ad31cf56)

An API that provides information on Netflix’s Movie and TV Show catalog.

### Technology Stack

- [ASP.NET Core 9.0 - FastEndpoints](https://fast-endpoints.com) for API development
- [OpenTelemetry (OTel)](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/observability-with-otel) for observability
- [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview) for development bootstrapping and client integrations
- [OpenAPI API client generation](https://openapi-generator.tech/docs/generators/typescript-angular/) for calling the API from the frontend
- [Gridify](https://alirezanet.github.io/Gridify) for filtering, ordering and paging
- [Scalar](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/using-openapi-documents?view=aspnetcore-9.0#use-scalar-for-interactive-api-documentation) for interactive API documentation
- [XUnit](https://xunit.net) for tests

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Docker or Podman

### Run in Aspire mode

This mode starts the API in the context of .NET Aspire.

1. Make sure the docker runtime is started.

2. Run the MoviesApi.AspireHost project with the `https` launch profile.

![image](https://github.com/user-attachments/assets/c7e131a4-6d06-40c7-bdc2-7e97eb08899f)

(The SQL Server container might take a little while to spin up.)

After all resources are running, they can be accessed via URLs:

- [Api](https://localhost:7445/scalar/v1)
- [Frontend](http://localhost:8000)
