using Entities;

namespace Strobing
{
    public interface IStroboscope<TVector>
        where TVector : IVector, new()
    {
        void Init(List<Ball<TVector>> balls);
        void Step(double timeStrobe);
    }
}
