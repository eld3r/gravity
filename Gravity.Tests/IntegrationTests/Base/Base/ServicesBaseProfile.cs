using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravity.Tests.IntegrationTests.Base;

[TestClass]
public class ServicesBaseProfile
{
    protected static ServiceProvider Services { get; set; } = null!;

    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static void ClassInitialize(TestContext tcnt)
    {
        var servicesCollection = new ServiceCollection();
        servicesCollection.RegisterStuff();
        Services = servicesCollection.BuildServiceProvider();
    }
}
