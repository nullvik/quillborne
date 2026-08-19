namespace quillborne.Services.Themes.Models;

public sealed class ThemeDefinition
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public ThemeColors Colors { get; set; } = new();
}
