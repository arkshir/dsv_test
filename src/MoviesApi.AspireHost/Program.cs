using Microsoft.Extensions.Hosting;

using Projects;

IDistributedApplicationBuilder? builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<ParameterResource> password = builder.AddParameter("MsSqlPassword", true);

IResourceBuilder<SqlServerServerResource>? sql = builder
    .AddSqlServer("mssql", password)
    .WithDataBindMount(Path.Combine("..", "..", "data", "mssql"))
    .WithLifetime(ContainerLifetime.Persistent)
    .WithEndpoint(1433, 1433, "tcp", "mssql");

IResourceBuilder<SqlServerDatabaseResource>? db = sql.AddDatabase("moviesdb");

IResourceBuilder<ProjectResource> moviesApi = builder.AddProject<MoviesApi_Api>("moviesapi")
    .WithEnvironment("ASPNETCORE_ASPIRE", "1")
    .WithReference(db)
    .WaitFor(db);

IResourceBuilder<NodeAppResource> moviesfrontend = builder.AddNpmApp("moviesfrontend", "../MoviesFrontend")
    .WithReference(moviesApi)
    .WaitFor(moviesApi)
    .WithHttpEndpoint(port: 8000, targetPort: 4200, env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

await builder.Build().RunAsync();