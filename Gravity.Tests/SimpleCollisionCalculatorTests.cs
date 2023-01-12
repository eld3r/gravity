using Calculators.Impl.TwoD;
using Calculators.Impl.TwoD.Collision;
using Entities;
using Entities.TwoD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Gravity.Tests;

[TestClass]
public class SimpleCollisionCalculatorTests
{
    static VectorOperator vectorOperator;
    static SimpleCollisionCalculus target;

    static Ball<TwoDimensionVector> ball0;
    static Ball<TwoDimensionVector> ball1;

    [ClassInitialize]
    public static void ClassInit(TestContext ctx)
    {
        vectorOperator = new VectorOperator();
        target = new SimpleCollisionCalculus(vectorOperator);

        ball0 = new Ball<TwoDimensionVector>();
        ball1 = new Ball<TwoDimensionVector>();
    }

    [TestMethod]
    public void CollisionTest_X()
    {


        ball0.Position = new TwoDimensionVector() {};
        ball0.Mass = 50;
        ball0.Velocity.X = -0.1;

        ball1.Position = new TwoDimensionVector() {};
        ball1.Mass = 50;
        ball1.Velocity.X = 0.1;

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(0.1d, 1E-8);
        ball1.Velocity.X.ShouldBe(-0.1d, 1E-8);
    }

    [TestMethod]
    public void CollisionTest_X_diffMasses()
    {
        VectorOperator vectorOperator = new VectorOperator();
        SimpleCollisionCalculus target = new SimpleCollisionCalculus(vectorOperator);

        Ball<TwoDimensionVector> ball0 = new Ball<TwoDimensionVector>();
        Ball<TwoDimensionVector> ball1 = new Ball<TwoDimensionVector>();

        ball0.Position = new TwoDimensionVector() {  };
        ball0.Mass = 50;
        ball0.Velocity.X = -0.1;

        ball1.Position = new TwoDimensionVector() {  };
        ball1.Mass = 250;
        ball1.Velocity.X = 0.1;

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(0.1d * 5, 1E-8);
        ball1.Velocity.X.ShouldBe(-0.1d / 5, 1E-8);
    }

    [TestMethod]
    public void CollisionTest_XY()
    {
        VectorOperator vectorOperator = new VectorOperator();
        SimpleCollisionCalculus target = new SimpleCollisionCalculus(vectorOperator);

        Ball<TwoDimensionVector> ball0 = new Ball<TwoDimensionVector>();
        Ball<TwoDimensionVector> ball1 = new Ball<TwoDimensionVector>();

        ball0.Position = new TwoDimensionVector() {  };
        ball0.Mass = 50;
        ball0.Velocity.X = -0.1;
        ball0.Velocity.Y = -0.1;

        ball1.Position = new TwoDimensionVector() { };
        ball1.Mass = 50;
        ball1.Velocity.X = 0.1;
        ball1.Velocity.Y = 0.1;

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(0.1d, 1E-8);
        ball1.Velocity.X.ShouldBe(-0.1d, 1E-8);
        ball0.Velocity.Y.ShouldBe(0.1d, 1E-8);
        ball1.Velocity.Y.ShouldBe(-0.1d, 1E-8);
    }

    [TestMethod]
    public void CollisionTest_X_DoubleCollisionTest()
    {
        ball0.Position = new TwoDimensionVector() { };
        ball0.Mass = 50;
        ball0.Velocity.X = -0.1;

        ball1.Position = new TwoDimensionVector() { };
        ball1.Mass = 50;
        ball1.Velocity.X = 0.1;

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(0.1d, 1E-8);
        ball1.Velocity.X.ShouldBe(-0.1d, 1E-8);

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(-0.1d, 1E-8);
        ball1.Velocity.X.ShouldBe(0.1d, 1E-8);
    }

    [TestMethod]
    public void CollisionTest_X_Billiard()
    {

        ball0.Position = new TwoDimensionVector() {};
        ball0.Mass = 50;
        ball0.Velocity.X = -0.5;
        ball0.Velocity.Y = 0;

        ball1.Position = new TwoDimensionVector() {};
        ball1.Mass = 50;
        ball1.Velocity.X = 0;
        ball1.Velocity.Y = 0;

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(-0d, 1E-8);
        ball1.Velocity.X.ShouldBe(-0.5d, 1E-8);

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(-0.5d , 1E-8);
        ball1.Velocity.X.ShouldBe(-0d, 1E-8);
    }

    [TestMethod]
    [Ignore("Wrong calculations")]
    public void CollisionTest_X_StrangeBug()
    {

        ball0.Position = new TwoDimensionVector() { };
        ball0.Mass = 50;
        ball0.Velocity.X = -0.5;
        ball0.Velocity.Y = 0;

        ball1.Position = new TwoDimensionVector() { };
        ball1.Mass = 150;
        ball1.Velocity.X = -0.1;
        ball1.Velocity.Y = 0;

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(-0.3, 1E-8);
        ball1.Velocity.X.ShouldBe(-0.1, 1E-8);
    }        
    
    [TestMethod]
    public void CollisionTest_X_del()
    {

        ball0.Position = new TwoDimensionVector() { X = 2, Y = 0 };
        ball0.Mass = 50;
        ball0.Velocity.X = -4;
        ball0.Velocity.Y = 0;

        ball1.Position = new TwoDimensionVector() { X = -2, Y = 0 };
        ball1.Mass = 200;
        ball1.Velocity.X = 1;
        ball1.Velocity.Y = 0;

        target.HandleCollision(0, ball0, ball1);

        ball0.Velocity.X.ShouldBe(4, 1E-8);
        ball1.Velocity.X.ShouldBe(-1, 1E-8);

    }
}
