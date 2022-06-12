namespace Sit.App.Core.Models;

public record InspectionRequest(
    string TargetUrl,
    string InpectionText,
    int MaxResultCount);