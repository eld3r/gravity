using Calculators.Interface;
using Entities;
using Entities.TwoD;

namespace Calculators.Impl.TwoD;

public class PathCalculus : IPathCalculus<TwoDimensionVector>
{
    public void CalcNextPosition(Ball<TwoDimensionVector> ball, double timeStrobe)
    {
        ball.Position.X += ball.Velocity.X * timeStrobe;
        ball.Position.Y += ball.Velocity.Y * timeStrobe;
    }
}
