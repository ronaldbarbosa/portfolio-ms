namespace portfolio_ms.DTOs;

public record CreateProjectRequest(string Name,  string Description, string ImgUrl, string DeployUrl, int ProjectType);