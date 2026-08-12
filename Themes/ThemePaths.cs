using System;
using System.IO;

namespace quillborne.Themes;

public static class ThemePaths
{
    public static string Directory
    {
        get
        {
            var appData = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);

            return Path.Combine(
                appData,
                "quillborne",
                "themes");
        }
    }
}
