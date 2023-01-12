using Calculators.Interface;
using Entities.TwoD;


namespace Calculators.Impl.TwoD;

public class SuperpositionForceCalculus : AbstractSuperpositionForceCalculus<TwoDimensionVector>
{
    public SuperpositionForceCalculus(IVectorOperator<TwoDimensionVector> vectorOperator) : base(vectorOperator) {}

    public override TwoDimensionVector CalcSingleForce(double force, double radius, TwoDimensionVector itemPosition, TwoDimensionVector innerPosition)
    {
        TwoDimensionVector singleForce = new TwoDimensionVector();

        singleForce.X = innerPosition.X - itemPosition.X;
        singleForce.Y = innerPosition.Y - itemPosition.Y;

        singleForce.X = singleForce.X * force / radius;
        singleForce.Y = singleForce.Y * force / radius;

        return singleForce;
    }
}
