using Calculators.Interface;
using Entities;
using Entities.TwoD;

namespace Calculators.Impl.TwoD.Walls;

public class DisposingWallAroundBall : IWall<TwoDimensionVector>
{
    public void Bounce(Ball<TwoDimensionVector> ball)
    {
        if (_targetBall == null)
            return;

        if (ball.Position.X <= _targetBall.Position.X - 150 || ball.Position.X >= _targetBall.Position.X + 150)
        {
            ball.Velocity.X = ball.Velocity.X * -1;
            ball.IsGone = true;
        }

        if (ball.Position.Y <= _targetBall.Position.Y - 150 || ball.Position.Y >= _targetBall.Position.Y + 150)
        {
            ball.Velocity.Y = ball.Velocity.Y * -1;
            ball.IsGone = true;
        }
    }


    Ball<TwoDimensionVector> _targetBall = null;
    public void SetTargetBall(Ball<TwoDimensionVector> ball)
    {
        _targetBall = ball;
    }
}
