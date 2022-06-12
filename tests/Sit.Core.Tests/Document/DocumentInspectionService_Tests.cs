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
    public void Inspect_UsingWebRespsitory_Used([Frozen] IWebRepository webRepository,
                                                DocumentInspectionService sut)
    {
        // Arrange
        const string TestLocation = "TestLocation";
        const string TestInspectionText = "TestInspectionTest";
        var inspectionRequest = new InspectionRequestDetail(TestLocation, TestInspectionText, 1688);

        // Act
        var result = sut.Inspect(inspectionRequest);

        // Assert
        A.CallTo(() => webRepository.GetContentFrom(TestLocation)).MustHaveHappenedOnceExactly();
    }
}