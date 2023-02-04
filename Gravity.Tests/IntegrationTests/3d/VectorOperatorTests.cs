using Calculators.Interface;
using Entities.ThreeD;
using Gravity.Tests.IntegrationTests.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravity.Tests.IntegrationTests._3d;

[TestClass]
public class VectorOperatorTests : ServicesBaseProfile
{
    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static void ClassInit(TestContext tc)
    {
        Target = Services.GetRequiredService<IVectorOperator<ThreeDimensionVector>>();
    }

    private static IVectorOperator<ThreeDimensionVector> Target { get; set; } = null!;

    [TestMethod]
    public void Test1()
    {
        var vec1 = new ThreeDimensionVector(1, 1, 1);
        var vec2 = new ThreeDimensionVector(2, 2, 2);
        Target.Append(vec1, vec2);

        vec1.X.ShouldBe(3);
        vec1.Y.ShouldBe(3);
        vec1.Z.ShouldBe(3);

        vec2.X.ShouldBe(2);
        vec2.Y.ShouldBe(2);
        vec2.Z.ShouldBe(2);
    }

}
