using Entities;

namespace Calculators.Interface;

public interface ICollisionCalculus<TVector>
    where TVector : IVector, new()
{
    public void HandleCollision(double range, Ball<TVector> ball, Ball<TVector> inner);
}
