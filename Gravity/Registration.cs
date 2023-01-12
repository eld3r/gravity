using Calculators.Impl;
using Calculators.Interface;
using Calculators.Impl.TwoD;
using Entities;
using Entities.TwoD;
using Microsoft.Extensions.DependencyInjection;
using Strobing;
using Strobing.Combinators;
using Calculators.Impl.TwoD.Collision;
using Calculators.Impl.TwoD.Walls;

namespace Gravity
{
    public static class RegistrationExtension
    {
        public static void RegisterStuff(this ServiceCollection services) => services
            .AddSingleton<IAtomicForceCalculus, AtomicForceCalculus>()

            .AddSingleton<IStroboscope<TwoDimensionVector>, Stroboscope<TwoDimensionVector>>()
            .AddSingleton<IRangeCalculus<TwoDimensionVector>, RangeCalculus>()
            .AddSingleton<ICombinator<Ball<TwoDimensionVector>>, RecursiveCombinator<Ball<TwoDimensionVector>>>()
            .AddSingleton<ISuperposionForceCalculus<TwoDimensionVector>, SuperpositionForceCalculus>()
            .AddSingleton<IVectorOperator<TwoDimensionVector>, VectorOperator>()
            .AddSingleton<ISpeedCalculus<TwoDimensionVector>, SpeedCalculus>()
            .AddSingleton<IPathCalculus<TwoDimensionVector>, PathCalculus>()
            .AddSingleton<ICollisionCalculus<TwoDimensionVector>, ImpulseConstCollisionCalculus>()
            .AddSingleton<IWall<TwoDimensionVector>, NoWalls>()
            ;
    }
}
