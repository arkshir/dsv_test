using Projects;

IDistributedApplicationBuilder? builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<ParameterResource>? password = builder.AddParameter("MsSqlPassword", true);

IResourceBuilder<SqlServerServerResource>? sql = builder
    .AddSqlServer("mssql", password)
    .WithDataBindMount(Path.Combine("..", "..", "data", "mssql"))
    .WithLifetime(ContainerLifetime.Persistent)
    .WithEndpoint(1433, 1433, "tcp", "mssql");

IResourceBuilder<SqlServerDatabaseResource>? db = sql.AddDatabase("moviesdb");

IResourceBuilder<ProjectResource>? apiService = builder.AddProject<MoviesApi_Api>("moviesapi")
    .WithEnvironment("ASPNETCORE_ASPIRE", "1")
    .WithReference(db)
    .WaitFor(db);

// builder.AddProject<Projects.MoviesApi_Web>("webfrontend")
//     .WithExternalHttpEndpoints()
//     .WithReference(apiService)
//     .WaitFor(apiService);

await builder.Build().RunAsync();