using AutoFixture.NUnit3;
using FakeItEasy;
using NUnit.Framework;
using Sit.Core.Document;
using Sit.Data;
using Sit.Tests.Core;

namespace Sit.Core.Tests.Document;

[TestFixture]
public class DocumentInspectionService_Tests
{
    [AutoFakeSutTest]
    public async Task InspectAsync_UsingWebRespsitory_Used([Frozen] IWebRepository webRepository,
        DocumentInspectionService sut)
    {
        // Arrange
        const string TestLocation = "TestLocation";
        const string TestInspectionText = "TestInspectionTest";
        var inspectionRequest = new InspectionRequestDetail(TestLocation, TestInspectionText, 1688);

        // Act
        var result = await sut.InspectAsync(inspectionRequest);

        // Assert
        A.CallTo(() => webRepository.GetContentFromAsync(TestLocation)).MustHaveHappenedOnceExactly();
    }

    [AutoFakeSutTest]
    public async Task InspectAsync_OneMatchingLinkOutOfThree_ReturnOneResult([Frozen] IDocumentTokenizer documentTokenizer,
        DocumentInspectionService sut)
    {
        // Arrange
        const string TestLocation = "TestLocation";
        const string TestInspectionText = "MatchingInspectionText";
        const int maxResultCount = 1688;
        var inspectionRequest = new InspectionRequestDetail(TestLocation, TestInspectionText, maxResultCount);

        var testTokens = new[]
        {
            new DocumentToken(0, "TestTextHere"),
            new DocumentToken(1, $"TestTextHere {TestInspectionText}"),
            new DocumentToken(2, "TestTextHere"),
        };

        A.CallTo(() => documentTokenizer.TokenizeHyperlinks(A<string>._, maxResultCount)).Returns(testTokens);

        // Act
        var result = await sut.InspectAsync(inspectionRequest);

        // Assert
        Assert.AreEqual(1, result.MatchTokens.Count);
        Assert.AreEqual(1, result.MatchTokens.First().Index);
    }

    [AutoFakeSutTest]
    public async Task InspectAsync_NoMatchingLinkOutOfThree_ReturnEmptyResult([Frozen] IDocumentTokenizer documentTokenizer,
        DocumentInspectionService sut)
    {
        // Arrange
        const string TestLocation = "TestLocation";
        const string TestInspectionText = "MatchingInspectionText";
        const int maxResultCount = 1688;
        var inspectionRequest = new InspectionRequestDetail(TestLocation, TestInspectionText, maxResultCount);

        var testTokens = new[]
        {
            new DocumentToken(0, "TestTextHere"),
            new DocumentToken(2, "TestTextHere"),
        };

        A.CallTo(() => documentTokenizer.TokenizeHyperlinks(A<string>._, maxResultCount)).Returns(testTokens);

        // Act
        var result = await sut.InspectAsync(inspectionRequest);

        // Assert
        Assert.AreEqual(0, result.MatchTokens.Count);
    }


}