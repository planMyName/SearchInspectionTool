using NUnit.Framework;
using Sit.Core.Document.Matcher;
using Sit.Tests.Core;

namespace Sit.Core.Tests.Document.Matcher;

[TestFixture]
public class HyperlinkMatcher_Tests
{
    [AutoFakeSutTest]
    public void GetNextMatch_FoundOneMatch_ReturnMatchHyperlink(HyperlinkMatcher sut)
    {
        // Arrange
        var content = "<html><head></head><body><a href=\"https://www.google.com.au\">TestLinkName</a></body></html>";
        sut.SetContent(content);

        // Act
        var result = sut.GetNextMatch();

        // Assert
        Assert.AreEqual("https://www.google.com.au", result);
    }

    [AutoFakeSutTest]
    public void GetNextMatch_NoMatch_ReturnEmptyString(HyperlinkMatcher sut)
    {
        // Arrange
        var content = "<html><head><script>const a = href;</script></head><body></body></html>";
        sut.SetContent(content);

        // Act
        var result = sut.GetNextMatch();

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [AutoFakeSutTest]
    public void GetNextMatch_NoContentSet_ReturnEmptyString(HyperlinkMatcher sut)
    {
        // Arrange

        // Act
        var result = sut.GetNextMatch();

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [AutoFakeSutTest]
    public void GetNextMatch_OnlyOneMatchCallThreeTime_ReturnEmptyString(HyperlinkMatcher sut)
    {
        // Arrange
        var content = "<html><head></head><body><a href=\"https://www.google.com.au\">TestLinkName</a></body></html>";
        sut.SetContent(content);

        // Act
        var result1 = sut.GetNextMatch();
        var result2 = sut.GetNextMatch();
        var result3 = sut.GetNextMatch();

        // Assert
        Assert.AreEqual("https://www.google.com.au", result1);
        Assert.AreEqual(string.Empty, result2);
        Assert.AreEqual(string.Empty, result3);
    }
}