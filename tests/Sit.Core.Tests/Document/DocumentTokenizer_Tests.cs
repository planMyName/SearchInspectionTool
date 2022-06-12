using AutoFixture.NUnit3;
using FakeItEasy;
using NUnit.Framework;
using Sit.Core.Document;
using Sit.Core.Document.Matcher;
using Sit.Tests.Core;

namespace Sit.Core.Tests.Document;

[TestFixture]
public class DocumentTokenizer_Tests
{
    [AutoFakeSutTest]
    public void TokenizeHyperlinks_TwoLinks_ExpectTwoToken([Frozen] IHyperlinkMatcher hyperlinkMatcher,
                                                            DocumentTokenizer sut)
    {
        // Arrange
        A.CallTo(()=>hyperlinkMatcher.GetNextMatch())
            .ReturnsNextFromSequence("GoodResult", "SecondGoodResult", string.Empty);

        // Act
        var tokens = sut.TokenizeHyperlinks("TestContent", 1000);

        // Assert
        Assert.AreEqual(2, tokens.Count);
    }

    [AutoFakeSutTest]
    public void TokenizeHyperlinks_TwoTokenWithRightIndex_ExpectTwoToken([Frozen] IHyperlinkMatcher hyperlinkMatcher,
                                                            DocumentTokenizer sut)
    {
        // Arrange
        A.CallTo(()=>hyperlinkMatcher.GetNextMatch())
            .ReturnsNextFromSequence("GoodResult", "SecondGoodResult", string.Empty);

        // Act
        var tokens = sut.TokenizeHyperlinks("TestContent", 1000).ToList();

        // Assert
        Assert.AreEqual(new DocumentToken(0, "GoodResult"), tokens[0]);
        Assert.AreEqual(new DocumentToken(1, "SecondGoodResult"), tokens[1]);
    }


    [AutoFakeSutTest]
    public void TokenizeHyperlinks_TwoLinksButOnlyAskForMaxOne_ExpectOneToken([Frozen] IHyperlinkMatcher hyperlinkMatcher,
        DocumentTokenizer sut)
    {
        // Arrange
        A.CallTo(() => hyperlinkMatcher.GetNextMatch())
            .ReturnsNextFromSequence("GoodResult", "SecondGoodResult", string.Empty);

        // Act
        var tokens = sut.TokenizeHyperlinks("TestContent", 1);

        // Assert
        Assert.AreEqual(1, tokens.Count);
        Assert.AreEqual("GoodResult", tokens.First().ExtractedContent);
    }


    [AutoFakeSutTest]
    public void TokenizeHyperlinks_NoMatch_ExpectEmptyCollection([Frozen] IHyperlinkMatcher hyperlinkMatcher,
        DocumentTokenizer sut)
    {
        // Arrange
        A.CallTo(() => hyperlinkMatcher.GetNextMatch()).Returns(string.Empty);

        // Act
        var tokens = sut.TokenizeHyperlinks("TestContent", 1000);

        // Assert
        Assert.AreEqual(0, tokens.Count);
        A.CallTo(() => hyperlinkMatcher.GetNextMatch()).MustHaveHappenedOnceExactly();
    }

}