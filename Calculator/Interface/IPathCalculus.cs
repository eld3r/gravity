using Entities;

namespace Calculators.Interface
{
    public interface IPathCalculus<TVector>
        where TVector : IVector, new()
    {
        void CalcNextPosition(Ball<TVector> ball, double timeStrobe);
    }
}
