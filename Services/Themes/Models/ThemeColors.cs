namespace quillborne.Services.Themes.Models;

public sealed class ThemeColors
{
    public string Background { get; set; } = string.Empty;
    public string Surface { get; set; } = string.Empty;
    public string SurfaceAlt { get; set; } = string.Empty;

    public string TextPrimary { get; set; } = string.Empty;
    public string TextSecondary { get; set; } = string.Empty;
    public string TextMuted { get; set; } = string.Empty;

    public string Border { get; set; } = string.Empty;
    public string BorderStrong { get; set; } = string.Empty;

    public string Highlight { get; set; } = string.Empty;
    public string HighlightHover { get; set; } = string.Empty;
    public string HighlightSoft { get; set; } = string.Empty;

    public string Selection { get; set; } = string.Empty;
    public string Cursor { get; set; } = string.Empty;

    public string Success { get; set; } = string.Empty;
    public string Warning { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;
}
