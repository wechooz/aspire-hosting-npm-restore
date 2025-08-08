var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApplication>("webapplication")
    .AddNpmRestore();

builder.Build().Run();
