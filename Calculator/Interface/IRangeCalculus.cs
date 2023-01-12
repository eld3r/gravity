using Entities;

namespace Calculators.Interface;


public interface IRangeCalculus<TVector> 
    where TVector : IVector
{
    double CalcRange(TVector coord, TVector coord1);
}
