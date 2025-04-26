namespace portfolio_ms.Models;

public class Project
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public string? DeployUrl { get; set; }
    public ProjectType ProjectType { get; set; }
}

public enum ProjectStatus
{
    Active,
    Inactive
}

public enum ProjectType
{
    Frontend,
    Backend
}