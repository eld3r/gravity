using Calculators.Interface;
using Entities;
using Entities.TwoD;


namespace Calculators.Impl.TwoD;

public class DisposingWall : IWall<TwoDimensionVector>
{
    public void Bounce(Ball<TwoDimensionVector> ball)
    {
        if (ball.Position.X > 150 || ball.Position.X < -150 ||
            ball.Position.Y > 150 || ball.Position.Y < -150)
            ball.IsGone = true;

    }
}
