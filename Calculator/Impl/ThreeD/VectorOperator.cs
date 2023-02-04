using Calculators.Interface;
using Entities.ThreeD;

namespace Calculators.Impl.ThreeD;

public class VectorOperator : IVectorOperator<ThreeDimensionVector>
{
    public void Append(ThreeDimensionVector vector, ThreeDimensionVector vector1)
    {
        vector.X += vector1.X;
        vector.Y += vector1.Y;
        vector.Z += vector1.Z;
    }

    public ThreeDimensionVector Sum(ThreeDimensionVector vector, ThreeDimensionVector vector1)
    {
        ThreeDimensionVector result = new ThreeDimensionVector();

        result.X = vector.X + vector1.X;
        result.Y = vector.Y + vector1.Y;
        result.Z = vector.Z + vector1.Z;

        return result;
    }

    public ThreeDimensionVector Invert(ThreeDimensionVector vector)
    {
        var result = (ThreeDimensionVector)vector.Clone();
        result.X *= -1;
        result.Y *= -1;
        result.Z *= -1;

        return result;
    }

    public ThreeDimensionVector MultiplyScalar(ThreeDimensionVector vector, double factor)
    {
        var result = (ThreeDimensionVector)vector.Clone();
        result.X *= factor;
        result.Y *= factor;
        result.Z *= factor;

        return result;
    }

    public ThreeDimensionVector MultiplyVector(ThreeDimensionVector vector, double factor)
    {
        var result = new ThreeDimensionVector();
        result.X = vector.X * factor;
        result.Y = vector.Y * factor;
        result.Z = vector.Z * factor;

        return result;
    }
}
