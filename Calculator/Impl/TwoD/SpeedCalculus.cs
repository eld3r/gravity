using Calculators.Interface;
using Entities;
using Entities.TwoD;

namespace Calculators.Impl.TwoD;

public class SpeedCalculus : ISpeedCalculus<TwoDimensionVector>
{
    IVectorOperator<TwoDimensionVector> _vectorOperator;
    public SpeedCalculus(IVectorOperator<TwoDimensionVector> vectorOperator)
    {
        _vectorOperator = vectorOperator;
    }
    public void CalcSpeed(Ball<TwoDimensionVector> ball, double timeStrobe)
    {
        //F = m * a;
        //a = F / m;
        //V = a * t;

        TwoDimensionVector newVelocity = new TwoDimensionVector();
        newVelocity.X = (ball.Force.X / ball.Mass) * timeStrobe;
        newVelocity.Y = (ball.Force.Y / ball.Mass) * timeStrobe;

        _vectorOperator.Append(ball.Velocity, newVelocity);
    }
}
