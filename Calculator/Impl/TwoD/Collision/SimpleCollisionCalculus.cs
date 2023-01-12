using Calculators.Interface;
using Entities;
using Entities.TwoD;

namespace Calculators.Impl.TwoD.Collision;

//TODO: maybe abstract type
public class SimpleCollisionCalculus : ICollisionCalculus<TwoDimensionVector>
{
    IVectorOperator<TwoDimensionVector> _vectorOperator;
    public SimpleCollisionCalculus(IVectorOperator<TwoDimensionVector> vectorOperator)
    {
        _vectorOperator = vectorOperator;
    }

    public void HandleCollision(double range, Ball<TwoDimensionVector> ball, Ball<TwoDimensionVector> inner)
    {
        if (range > ball.Radius + inner.Radius)
            return;

        var prevVelocity = (TwoDimensionVector)ball.Velocity.Clone();

        var massRatio = inner.Mass / ball.Mass;

        ball.Velocity = _vectorOperator.MultiplyVector(inner.Velocity, massRatio);
        inner.Velocity = _vectorOperator.MultiplyVector(prevVelocity, 1.0d / massRatio);
    }
}
