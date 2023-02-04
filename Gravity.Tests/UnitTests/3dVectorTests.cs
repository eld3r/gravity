using Entities.ThreeD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace Gravity.Tests.UnitTests;

[TestClass]
public class _3dVectorTests 
{
    [TestMethod]
    public void CtorTest()
    {
        var target = new ThreeDimensionVector(1, 2, 3);

        target.X.ShouldBe(1);
        target.Y.ShouldBe(2);
        target.Z.ShouldBe(3);
    }
    
    [TestMethod]
    public void ZeroTest()
    {
        var target = new ThreeDimensionVector(1, 2, 3);

        target.Zero();

        target.X.ShouldBe(0);
        target.Y.ShouldBe(0);
        target.Z.ShouldBe(0);

        var target1 = new ThreeDimensionVector();

        target1.X.ShouldBe(0);
        target1.Y.ShouldBe(0);
        target1.Z.ShouldBe(0);
    }

    [TestMethod]
    public void CloneTest()
    {
        var target = new ThreeDimensionVector(1, 2, 3);

        var clone = target.Clone() as ThreeDimensionVector;

        clone.ShouldNotBeNull();

        clone.X.ShouldBe(1);
        clone.Y.ShouldBe(2);
        clone.Z.ShouldBe(3);

        clone.ShouldNotBe(target);
    }

    [TestMethod]
    public void IsNanTest()
    {
        var target = new ThreeDimensionVector(1, 2, 3);

        target.IsNan().ShouldBeFalse();

        target.X = Double.NaN;
        target.IsNan().ShouldBeTrue();

        target.X = 1;
        target.IsNan().ShouldBeFalse();

        target.Y = Double.NaN;
        target.IsNan().ShouldBeTrue();

        target.Y = 1;
        target.IsNan().ShouldBeFalse();

        target.Z = Double.NaN;
        target.IsNan().ShouldBeTrue();

        target.Z = 1;
        target.IsNan().ShouldBeFalse();


    }
}
