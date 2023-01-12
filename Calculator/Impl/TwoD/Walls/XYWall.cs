using Calculators.Interface;
using Entities;
using Entities.TwoD;

public class XYWall : IWall<TwoDimensionVector>
{
    public void Bounce(Ball<TwoDimensionVector> ball)
    {
        if (ball.Position.X <= -80 || ball.Position.X >= +80)
        {
            ball.Velocity.X = ball.Velocity.X * -1;
            ball.BounceCount++;
        }

        if (ball.Position.Y <= -50 || ball.Position.Y >= +50)
        {
            ball.Velocity.Y = ball.Velocity.Y * -1;
            ball.BounceCount++;
        }
    }
}
