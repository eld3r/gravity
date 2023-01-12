using Calculators.Interface;
using Entities;
using Entities.TwoD;

public class NoWalls : IWall<TwoDimensionVector>
{
    public void Bounce(Ball<TwoDimensionVector> ball)
    {
        //No breaks!
    }
}
