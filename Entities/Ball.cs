namespace Entities;

public class Ball<TVector>
    where TVector : IVector, new()
{
    public TVector Position { get; set; }
    public double Mass { get; set; }
    public TVector Velocity { get; set; }
    public TVector Force { get; set; }
    public double Density { get; set; } = 8;

    public bool IsGone { get; set; } = false;

    public int BounceCount { get; set; }
    public double Radius
    {
        //TODO: maybe some balls factory
        get
        {
            if (_radius >= 0)
                return _radius;

            var volume = Mass / Density;

            //V = 4/3 *pi * r^3
            //r^3 = (3 * V) / (4 * pi)

            _radius = Math.Pow((3 * volume) / (4 * Math.PI), 1d / 3d);

            return _radius;
                
        }
    }
    private double _radius = -1;
    public Ball()
    {
        Force = new TVector();
        Velocity = new TVector();
        Position = new TVector();
    }
}
