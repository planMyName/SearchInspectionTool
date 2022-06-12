namespace Sit.Core.Document
{
    public record InspectionRequestDetail(
        string TargetUrl,
        string InpectionText,
        int MaxResultCount);
}
