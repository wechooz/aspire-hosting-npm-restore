using Aspire.Hosting.ApplicationModel;

using WeChooz.Aspire.Hosting.NpmRestore;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Aspire.Hosting;
#pragma warning restore IDE0130 // Namespace does not match folder structure
/// <summary>
/// Extension methods to support adding npm restore inside .NET project to the <see cref="IResourceBuilder{ProjectResource}"/>.
/// </summary>
public static class NpmRestoreExtensions
{
    /// <summary>
    /// Adds an npm restore step to the launch of the project
    /// </summary>
    /// <param name="projectResourceBuilder">The resource representing the project.</param>
    /// <param name="configure">An action to configure the npm restore resource.</param>
    /// <returns>The resource representing the project.</returns>
    /// <exception cref="ArgumentNullException">If the project is null</exception>
    public static IResourceBuilder<ProjectResource> AddNpmRestore(this IResourceBuilder<ProjectResource> projectResourceBuilder, Action<NpmRestoreOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(projectResourceBuilder);

        var defaultOptions = new NpmRestoreOptions();
        configure?.Invoke(defaultOptions);

        string[] installArgs = defaultOptions.RestoreCommandAndArgs;
        var projectMetadata = projectResourceBuilder.Resource.GetProjectMetadata();
        var workingDirectory = Path.GetDirectoryName(projectMetadata.ProjectPath) ?? throw new ArgumentNullException(nameof(projectMetadata.ProjectPath));
        var npmRestoreResource = new ExecutableResource(defaultOptions.ResourceNameFormat(projectResourceBuilder.Resource.Name), defaultOptions.PackageManagerExecutableName, workingDirectory);

        var applicationBuilder = projectResourceBuilder.ApplicationBuilder;
        var npmRestoreResourceBuilder = applicationBuilder.AddResource(npmRestoreResource).WithArgs(installArgs)
            .WithParentRelationship(projectResourceBuilder.Resource);
        if (defaultOptions.AlwaysRun)
        {
            projectResourceBuilder.WaitForCompletion(npmRestoreResourceBuilder);
        }
        else
        {
            npmRestoreResourceBuilder.WithExplicitStart();
        }

        return projectResourceBuilder;
    }
}
