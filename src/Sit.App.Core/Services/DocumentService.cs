using AutoMapper;
using Sit.App.Core.Models;
using Sit.Core.Document;

namespace Sit.App.Core.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentInspectionService _documentInspectionService;
    private readonly IMapper _mapper;

    public DocumentService(IDocumentInspectionService documentInspectionService, IMapper mapper)
    {
        _documentInspectionService = documentInspectionService;
        _mapper = mapper;
    }

    public async Task<InspectionResult> Inspect(InspectionRequest inspectionRequest)
    {
        var result = await _documentInspectionService.Inspect(_mapper.Map<InspectionRequestDetail>(inspectionRequest));

        return _mapper.Map<InspectionResult>(result);
    }
}