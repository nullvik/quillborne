namespace quillborne.Services.Settings;

public interface ISettingsService
{
    AppSettings Current { get; }

    AppSettings Load();

    void Save();
}
