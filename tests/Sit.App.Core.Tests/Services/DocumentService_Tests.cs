using AutoFixture.NUnit3;
using FakeItEasy;
using NUnit.Framework;
using Sit.App.Core.Models;
using Sit.App.Core.Services;
using Sit.Core.Document;
using Sit.Tests.Core;

namespace Sit.App.Core.Tests.Services;

[TestFixture]
public class DocumentService_Tests
{
    [AutoFakeSutTest]
    public async Task InspectAsync_ThreeResultReturned_CSVstringReturned(
        [Frozen] IDocumentInspectionService documentInspectionService,
        DocumentService sut)
    {
        // Arrange
        var fakeResult = new List<DocumentToken>
        {
            new (1, "testContent"),
            new (2, "testContest2"),
            new (3, "TestContent3")
        };
        A.CallTo(() => documentInspectionService.InspectAsync(A<InspectionRequestDetail>._))
            .Returns(new InspectionResultDetail(fakeResult));

        // Act
        var result = await sut.InspectAsync(new InspectionRequest("testUrl", "testText", 100));

        // Assert
        Assert.AreEqual("1,2,3", result.ResultCsv);
    }

    [AutoFakeSutTest]
    public async Task InspectAsync_NoResultReturned_EmptyReturned(
        [Frozen] IDocumentInspectionService documentInspectionService,
        DocumentService sut)
    {
        // Arrange
        var fakeResult = new List<DocumentToken>();
        A.CallTo(() => documentInspectionService.InspectAsync(A<InspectionRequestDetail>._))
            .Returns(new InspectionResultDetail(fakeResult));

        // Act
        var result = await sut.InspectAsync(new InspectionRequest("testUrl", "testText", 100));

        // Assert
        Assert.AreEqual(string.Empty, result.ResultCsv);
    }

}