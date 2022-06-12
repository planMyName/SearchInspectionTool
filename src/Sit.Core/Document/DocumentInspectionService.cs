using Sit.Data;

namespace Sit.Core.Document;

public class DocumentInspectionService : IDocumentInspectionService
{
    private readonly IWebRepository _webRepository;
    private readonly IDocumentTokenizer _documentTokenizer;

    public DocumentInspectionService(IWebRepository webRepository, IDocumentTokenizer documentTokenizer)
    {
        _webRepository = webRepository;
        _documentTokenizer = documentTokenizer;
    }


    public async Task<InspectionResultDetail> Inspect(InspectionRequestDetail inspectionRequest)
    {
        var result = await _webRepository.GetContentFrom(inspectionRequest.TargetUrl);

        var hyperlinks = _documentTokenizer.TokenizeHyperlinks(result);


        return new InspectionResultDetail("1,2,3", result.Substring(0, 200));
    }
}