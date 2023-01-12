using Entities;

namespace Calculators.Interface;

public interface ISpeedCalculus<TVector>
        where TVector : IVector, new()
{
    public void CalcSpeed(Ball<TVector> ball, double timeStrobe);
}
