using Gravity.Tests.IntegrationTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculators.Interface;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Gravity.Tests.IntegrationTests;

[TestClass]
public class AtomicForceCalculusTests : ServicesBaseProfile
{
    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static void ClassInit(TestContext tc)
    {
        Target = Services.GetRequiredService<IAtomicForceCalculus>();
    }

    private static IAtomicForceCalculus Target { get; set; } = null!;

    [TestMethod]
    public void CalcForceTest()
    {
        var then = Target.CalcForce(1, 1, 1);
        then.ShouldBe(6.67E-11);

        then = Target.CalcForce(2, 2, 2);
        then.ShouldBe(6.67E-11);

        then = Target.CalcForce(2, 2, 1);
        then.ShouldBe(6.67E-11 * 4);
    }
}
