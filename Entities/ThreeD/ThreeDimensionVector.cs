namespace Entities.ThreeD;

public class ThreeDimensionVector : IVector
{
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;
    public double Z { get; set; } = 0;

    public ThreeDimensionVector()
    {
        Zero();
    }

    public ThreeDimensionVector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public IVector Clone()
    {
        return new ThreeDimensionVector() { X = X, Y = Y, Z = Z };
    }

    public bool IsNan()
    {
        return double.IsNaN(X) || double.IsNaN(Y) || double.IsNaN(Z);
    }

    public void Zero()
    {
        X = 0;
        Y = 0;
        Z = 0;
    }
}
