namespace quillborne.Services.Projects;

public interface IProjectService
{
    void NewProject();
    void OpenProject();
    void OpenRecentProject();
    void OpenProjectInNewWindow();
    void SaveProject();
    void RenameProject();
    bool DoesProjectExist();
}
