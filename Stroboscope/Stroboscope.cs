using Calculators.Interface;
using Entities;
using Strobing.Combinators;

namespace Strobing;

public class Stroboscope<TVector> : IStroboscope<TVector>
        where TVector : IVector, new()
{
    ICombinator<Ball<TVector>> _combinator;
    
    private IRangeCalculus<TVector> _rangeCalculus;
    private IAtomicForceCalculus _atomicForceCalculus;
    private ISuperposionForceCalculus<TVector> _superpositionForceCalculus;
    private ISpeedCalculus<TVector> _speedCalculus;
    private IPathCalculus<TVector> _pathCalculus;
    private ICollisionCalculus<TVector> _collisionChecker;
    private IWall<TVector> _wall;

    public Stroboscope(
        ICombinator<Ball<TVector>> combinator,
        IRangeCalculus<TVector> rangeCalculus, 
        IAtomicForceCalculus atomicForceCalculus,
        ISuperposionForceCalculus<TVector> superpositionForceCalculus,
        ISpeedCalculus<TVector> speedCalculus,
        IPathCalculus<TVector> pathCalculus,
        ICollisionCalculus<TVector> collisionChecker,
        IWall<TVector> wall
        )
    {
        _combinator = combinator;
        _rangeCalculus = rangeCalculus;
        _atomicForceCalculus = atomicForceCalculus;
        _superpositionForceCalculus = superpositionForceCalculus;
        _speedCalculus = speedCalculus;
        _pathCalculus = pathCalculus;
        _collisionChecker = collisionChecker;
        _wall = wall;
    }

    private List<Ball<TVector>> _balls;
    private int strobeCounter = 0;
    public void Init(List<Ball<TVector>> balls)
    {
        _balls = balls;
    }

    public void Step(double timeStrobe)
    {
        //TODO: own exception
        if (_balls == null)
            throw new Exception("Maybe forgot to init Stroboscope?");

        _combinator.Combine(_balls, (ball, ballInner) =>
        {
            if (ball.IsGone || ballInner.IsGone)
                return;

            var range = _rangeCalculus.CalcRange(ball.Position, ballInner.Position);

            if (range == 0)
            {
                ballInner.IsGone = true;
                return;
            }

            _collisionChecker.HandleCollision(range, ball, ballInner);

            var force = _atomicForceCalculus.CalcForce(ball.Mass, ballInner.Mass, range);

            if (double.IsNaN(force))
                return;

            _superpositionForceCalculus.OverlapForces(force, range, ball, ballInner);

        });

        _combinator.Enumerate(_balls, (ball) =>
        {
            if (ball.IsGone)
                return;

            _wall.Bounce(ball);
            _speedCalculus.CalcSpeed(ball, timeStrobe);
            _pathCalculus.CalcNextPosition(ball, timeStrobe);

            ball.Force.Zero();
        });

        _balls.RemoveAll(r => r.IsGone);

        strobeCounter++;
    }
}


