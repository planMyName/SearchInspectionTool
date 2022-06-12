using Sit.Core.Document.Matcher;

namespace Sit.Core.Document;

public class DocumentTokenizer : IDocumentTokenizer
{
    private readonly IHyperlinkMatcher _hyperlinkMatcher;

    public DocumentTokenizer(IHyperlinkMatcher hyperlinkMatcher)
    {
        _hyperlinkMatcher = hyperlinkMatcher;
    }

    public ICollection<DocumentToken> TokenizeHyperlinks(string content, int maxTokenCount)
    {
        _hyperlinkMatcher.SetContent(content);
        var tokens = Tokenize(_hyperlinkMatcher.GetNextMatch, maxTokenCount);

        return tokens;
    }

    private ICollection<DocumentToken> Tokenize(Func<string> matchFunc, int maxTokenCount)
    {
        List<DocumentToken> tokens = new List<DocumentToken>();

        var matchResult = matchFunc();
        var index = 0;

        while (matchResult != string.Empty && tokens.Count < maxTokenCount)
        {
            tokens.Add(new DocumentToken(index++, matchResult));
            matchResult = matchFunc();
        }

        return tokens;
    }
}