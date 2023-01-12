using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators.Interface;

public interface IWall<TVector>
    where TVector : IVector, new()
{
    void Bounce(Ball<TVector> ball);
}
