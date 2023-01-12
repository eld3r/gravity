using Calculators.Interface;
using Entities;
using Entities.TwoD;

namespace Calculators.Impl.TwoD;

public class PulseConstCollisionCalculus : ICollisionCalculus<TwoDimensionVector>
{
    int counter;

    public void HandleCollision(double range, Ball<TwoDimensionVector> ball, Ball<TwoDimensionVector> inner)
    {
        if (range > ball.Radius + inner.Radius)
            return;

        ball.BounceCount++;
        inner.BounceCount++;

        var prevVelocity = (TwoDimensionVector)ball.Velocity.Clone();

        ball.Velocity.X = GetVelosityFromOpposed(ball, inner.Mass, inner.Velocity.X);
        inner.Velocity.X = GetVelosityFromOpposed(inner, ball.Mass, prevVelocity.X);
    }

    private double GetVelosityFromOpposed(Ball<TwoDimensionVector> ball, double opposedMass, double opposedVelocity)
    {
        return ((ball.Mass - opposedMass) * ball.Velocity.X + (2 * opposedMass * opposedVelocity)) / (ball.Mass + opposedMass);
    }
}
