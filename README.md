# WeChooz Aspire Hosting npm restore

[![CI](https://github.com/CommunityToolkit/Aspire/actions/workflows/dotnet-ci.yml/badge.svg)](https://github.com/CommunityToolkit/Aspire/actions/workflows/dotnet-ci.yml) | [![main branch](https://github.com/CommunityToolkit/Aspire/actions/workflows/dotnet-main.yml/badge.svg)](https://github.com/CommunityToolkit/Aspire/actions/workflows/dotnet-main.yml) | [![Latest Release](https://github.com/CommunityToolkit/Aspire/actions/workflows/dotnet-release.yml/badge.svg)](https://github.com/CommunityToolkit/Aspire/actions/workflows/dotnet-release.yml)

This project adds the ability to restore npm packages when launching a project in .NET Aspire.

## Get started

To get started, install the install the [📦 WeChooz.Aspire.Hosting.NpmRestore](https://nuget.org/packages/WeChooz.Aspire.Hosting.NpmRestore) NuGet package in the AppHost project.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package WeChooz.Aspire.Hosting.NpmRestore
```
## Example usage

To add the `npm restore` resource, call the `AddNpmRestore` method on a `IResourceBuilder<ProjectResource>` instance (after calling `AddProject`):

```csharp
builder.AddProject<Projects.WebApplication>("webapplication")
       .AddNpmRestore();
```

You can configure some options by passing a delegate to the `AddNpmRestore` method:


```csharp
builder.AddProject<Projects.WebApplication>("webapplication")
       .AddNpmRestore(options => {...});
```

Following options are available:

| Name | Default value | Description |
| --- | --- | --- |
| AlwaysRun | `true` | Defines if the resource should always run, or should be explicitly run. |
| PackageManagerExecutableName | `"npm"` | Defines the name of the executable to process the package restore. |
| RestoreCommandAndArgs | `["i"]` | Defines the command to execute to restore the packages.  
| ResourceNameFormat | `(string projectName) => $"{projectName}-restore"` | Defines the format to compute the name of the restore resource from the name of the project. |
