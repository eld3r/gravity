using Calculators.Interface;
using Entities;

namespace Calculators.Impl.OneD;

internal class OneDimensionSuperpositionForceCalculus : AbstractSuperpositionForceCalculus<OneDimensionVector>
{
    public OneDimensionSuperpositionForceCalculus(IVectorOperator<OneDimensionVector> vectorOperator) : base(vectorOperator)
    {
    }

    public override OneDimensionVector CalcSingleForce(double force, double radius, OneDimensionVector itemPosition, OneDimensionVector innerPosition)
    {
        throw new NotImplementedException();
    }
}
