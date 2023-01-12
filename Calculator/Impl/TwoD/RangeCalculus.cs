using Calculators.Interface;
using Entities.TwoD;

namespace Calculators.Impl.TwoD;

public class RangeCalculus : IRangeCalculus<TwoDimensionVector>
{
    public double CalcRange(TwoDimensionVector coord, TwoDimensionVector coord1)
    {
        var dx = coord1.X - coord.X;
        var dy = coord1.Y - coord.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
