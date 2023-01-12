namespace Calculators.Interface;

public interface IVectorOperator<TVector>
{
    public void Append(TVector vector, TVector vector1);

    public TVector Sum(TVector vector, TVector vector1);

    public TVector Invert(TVector vector);

    TVector MultiplyScalar(TVector vector, double factor);

    TVector MultiplyVector(TVector vector, double factor);
}
