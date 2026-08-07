var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApplication>("webapplication")
    .AddNpmRestore();

await builder.Build().RunAsync();
