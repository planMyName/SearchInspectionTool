namespace Sit.Core.Document;

public interface IDocumentInspectionService
{
    Task<InspectionResultDetail> InspectAsync(InspectionRequestDetail inspectionRequest);
}