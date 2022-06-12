namespace Sit.Core.Document.Matcher;

public interface IHyperlinkMatcher
{
    void SetContent(string content);
    string GetNextMatch();
}