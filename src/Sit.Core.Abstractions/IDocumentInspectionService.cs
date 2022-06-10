namespace Sit.Core.Abstractions
{
    public interface IDocumentInspectionService
    {
        Task<InspectionResultDetail> Inspect(InspectionRequestDetail inspectionRequest);
    }
}