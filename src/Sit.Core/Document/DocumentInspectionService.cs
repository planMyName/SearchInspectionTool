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


    public async Task<InspectionResultDetail> InspectAsync(InspectionRequestDetail inspectionRequest)
    {
        var result = await _webRepository.GetContentFromAsync(inspectionRequest.TargetUrl);

        var hyperlinks = _documentTokenizer.TokenizeHyperlinks(result, inspectionRequest.MaxResultCount);

        var matchingHyperLinks =
            hyperlinks.Where(link => link.ExtractedContent.Contains(inspectionRequest.InpectionText)).ToList();


        return new InspectionResultDetail(matchingHyperLinks);
    }
}