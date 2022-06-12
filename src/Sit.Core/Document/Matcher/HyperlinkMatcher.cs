using System.Text.RegularExpressions;

namespace Sit.Core.Document.Matcher;

public class HyperlinkMatcher : IHyperlinkMatcher
{
    private readonly Regex _linkRegex;
    private Match? _match;
    private string? _content;

    // reference: https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-example-scanning-for-hrefs
    private const string HrefPattern = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";
    private const int RegexTimeoutInSeconds = 2;

    public HyperlinkMatcher()
    {
        _linkRegex = new Regex(HrefPattern,
            RegexOptions.Compiled | RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(RegexTimeoutInSeconds));

    }

    public void SetContent(string content)
    {
        _content = content;
        _match = null;
    }

    public string GetNextMatch()
    {
        if (_content == null)
        {
            return string.Empty;
        }

        if (_match == null)
        {
            _match = _linkRegex.Match(_content);
        }
        else if (_match.Success)
        {
            _match = _match.NextMatch();
        }

        return _match.Success ? _match.Groups[1].ToString() : string.Empty;
    }

}

