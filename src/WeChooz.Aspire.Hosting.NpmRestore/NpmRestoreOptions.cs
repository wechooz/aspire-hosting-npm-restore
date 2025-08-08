namespace WeChooz.Aspire.Hosting.NpmRestore;
/// <summary>
/// The options for the npm restore resource.
/// </summary>
public class NpmRestoreOptions
{
    /// <summary>
    /// Defines if the resource should always run, or should be explicitly run. <code>true</code> by default.
    /// </summary>
    public bool AlwaysRun { get; set; } = true;
    /// <summary>
    /// Defines the name of the executable to process the package restore. <code>npm</code> by default.
    /// </summary>
    public string PackageManagerExecutableName { get; set; } = "npm";
    /// <summary>
    /// Defines the command to execute to restore the packages. <code>["i"]</code> by default.
    /// </summary>
    public string[] RestoreCommandAndArgs { get; set; } = ["i"];
    /// <summary>
    /// Defines the format to compute the name of the restore resource from the name of the project. Format as <code>"{projectName}-restore"</code> by default.
    /// </summary>
    public Func<string, string> ResourceNameFormat { get; set; } = (string projectName) => $"{projectName}-restore";
}
