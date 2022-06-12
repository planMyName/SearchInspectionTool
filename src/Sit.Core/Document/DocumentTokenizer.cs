using Sit.Core.Document.Matcher;

namespace Sit.Core.Document;

public class DocumentTokenizer : IDocumentTokenizer
{
    public DocumentTokenizer(IHyperlinkMatcher hyperlinkMatcher)
    {
        
    }
    public ICollection<DocumentToken> TokenizeHyperlinks(string result)
    {
        throw new NotImplementedException();
    }
}