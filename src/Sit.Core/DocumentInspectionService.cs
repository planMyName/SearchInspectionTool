using Sit.Core.Abstractions;
using Sit.Data.Abstractions;

namespace Sit.Core
{
    public class DocumentInspectionService : IDocumentInspectionService
    {
        private readonly IWebRepository _webRepository;

        public DocumentInspectionService(IWebRepository webRepository)
        {
            _webRepository = webRepository;
        }


        public async Task<InspectionResultDetail> Inspect(InspectionRequestDetail inspectionRequest)
        {
            var result = await _webRepository.GetContentFrom(inspectionRequest.TargetUrl);

            return new InspectionResultDetail("1,2,3", result.Substring(0, 200));
        }
    }
}