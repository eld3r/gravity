using Entities;

namespace Calculators.Interface
{
    public abstract class AbstractSuperpositionForceCalculus<TVector> : ISuperposionForceCalculus<TVector>
        where TVector : IVector, new()
    {
        protected readonly IVectorOperator<TVector> _vectorOperator;

        public AbstractSuperpositionForceCalculus(IVectorOperator<TVector> vectorOperator)
        {
            _vectorOperator = vectorOperator;
        }
        public void OverlapForces(double force, double radius, Ball<TVector> item, Ball<TVector> inner)
        {
            var singleForce = CalcSingleForce(force, radius, item.Position, inner.Position);
            var singleForceInverted = _vectorOperator.Invert(singleForce);

            _vectorOperator.Append(item.Force, singleForce);
            _vectorOperator.Append(inner.Force, singleForceInverted);
        }

        public abstract TVector CalcSingleForce(double force, double radius, TVector itemPosition, TVector innerPosition);
    }
}
