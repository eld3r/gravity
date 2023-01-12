using Entities;

namespace Calculators.Interface;

public interface ISuperposionForceCalculus<TVector>
        where TVector : IVector, new()
{
    public void OverlapForces(double force, double radius, Ball<TVector> item, Ball<TVector> inner);
}
