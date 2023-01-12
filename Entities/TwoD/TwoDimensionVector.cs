namespace Entities.TwoD;

public class TwoDimensionVector : IVector
{
    public TwoDimensionVector()
    {
        Zero();
    }

    public TwoDimensionVector(double x, double y)
    {
        X = x;
        Y = y;

    }

    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;

    public IVector Clone()
    {
        return new TwoDimensionVector() { X = X, Y = Y };
    }

    public void Zero()
    {
        X = 0;
        Y = 0;
    }

    public override string ToString()
    {
        return $"X={X}; Y={Y}";
    }

    public bool IsNan()
    {
        return double.IsNaN(X) || double.IsNaN(Y);
    }
}
