namespace Sit.Core.Document
{
    public interface IDocumentInspectionService
    {
        Task<InspectionResultDetail> Inspect(InspectionRequestDetail inspectionRequest);
    }
}