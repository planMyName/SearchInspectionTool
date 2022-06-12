using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.NUnit3;

namespace Sit.Tests.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AutoFakeSutTestAttribute : AutoDataAttribute
    {
        public AutoFakeSutTestAttribute() : base(CreateBasicFixture)
        {
        }

        public static IFixture CreateBasicFixture()
        {
            var fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());
            return fixture;
        }
    }
}