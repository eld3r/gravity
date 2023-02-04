using Calculators.Interface;
using Entities.TwoD;


namespace Calculators.Impl.TwoD;

public class VectorOperator : IVectorOperator<TwoDimensionVector>
{
    public void Append(TwoDimensionVector vector, TwoDimensionVector vector1)
    {
        vector.X += vector1.X;
        vector.Y += vector1.Y;
    }

    public TwoDimensionVector Sum(TwoDimensionVector vector, TwoDimensionVector vector1)
    {
        TwoDimensionVector result = new TwoDimensionVector();

        result.X = vector.X + vector1.X;
        result.Y = vector.Y + vector1.Y;

        return result;
    }

    public TwoDimensionVector Invert(TwoDimensionVector vector)
    {
        var result = (TwoDimensionVector)vector.Clone();
        result.X *= -1;
        result.Y *= -1;

        return result;
    }

    public TwoDimensionVector MultiplyScalar(TwoDimensionVector vector, double factor)
    {
        var result = (TwoDimensionVector)vector.Clone();
        result.X *= factor;
        result.Y *= factor;

        return result;
    }

    public TwoDimensionVector MultiplyVector(TwoDimensionVector vector, double factor)
    {
        var result = new TwoDimensionVector();
        result.X = vector.X * factor;
        result.Y = vector.Y * factor;

        return result;
    }
}
