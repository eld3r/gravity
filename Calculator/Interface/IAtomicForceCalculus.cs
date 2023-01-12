namespace Calculators.Interface;

public interface IAtomicForceCalculus
{
    public double CalcForce(double mass1, double mass2, double range);
}
