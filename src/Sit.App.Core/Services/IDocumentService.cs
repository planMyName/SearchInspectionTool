using Sit.App.Core.Models;

namespace Sit.App.Core.Services;

public interface IDocumentService
{
    Task<InspectionResult> InspectAsync(InspectionRequest inspectionRequest);
}