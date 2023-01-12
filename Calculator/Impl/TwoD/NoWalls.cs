using Calculators.Interface;
using Entities;
using Entities.TwoD;

namespace Calculators.Impl.TwoD
{
    public class NoWalls : IWall<TwoDimensionVector>
    {
        public void Bounce(Ball<TwoDimensionVector> ball)
        {
            //No breaks!
        }
    }
}
