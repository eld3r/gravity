using Calculators.Interface;
using Entities;

namespace Calculators.Impl.OneD;

public class OneDimensionRangeCalculus : IRangeCalculus<OneDimensionVector>
{
    public double CalcRange(OneDimensionVector coord, OneDimensionVector coord1)
    {
        return Math.Abs(coord.X - coord1.X);
    }
}
