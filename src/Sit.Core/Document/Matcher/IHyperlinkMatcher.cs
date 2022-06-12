namespace Sit.Core.Document.Matcher;

public interface IHyperlinkMatcher
{
    public string GetNextMatch(int offset);
}