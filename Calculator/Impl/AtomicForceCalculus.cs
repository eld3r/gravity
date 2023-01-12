using Calculators.Interface;

namespace Calculators.Impl;

public class AtomicForceCalculus : IAtomicForceCalculus
{
    public const double Gconst = 6.67E-11;
    public double CalcForce(double mass1, double mass2, double range)
    {
        return (Gconst * mass1 * mass2) / (range * range);
    }
}
