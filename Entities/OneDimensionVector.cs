namespace Entities;

public class OneDimensionVector : IVector
{
    public double X { get; set; } = 0;

    public bool IsNan()
    {
        return double.IsNaN(X);
    }

    public void Zero()
    {
        X = 0;
    }

    IVector ICustClonable<IVector>.Clone()
    {
        throw new NotImplementedException();
    }
}
