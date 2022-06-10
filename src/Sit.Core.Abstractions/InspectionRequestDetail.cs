namespace Sit.Core.Abstractions
{
    public record InspectionRequestDetail(
        string TargetUrl,
        string InpectionText,
        int MaxResultCount);
}
