namespace quillborne.Services.Projects;

public interface IProjectService
{
    void NewProject();
    void OpenProject();
    void OpenProjectInNewWindow();
    void SaveProject();
    void RenameProject();
}
