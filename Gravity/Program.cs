using Entities;
using Microsoft.Extensions.DependencyInjection;
using Strobing;
using Gravity;
using Entities.TwoD;
using BlotchExample;
using Jobs;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

services.RegisterStuff();

var serviceProvider = services.BuildServiceProvider();
var stroboscope = serviceProvider.GetRequiredService<IStroboscope<TwoDimensionVector>>();


var balls = JobHelper2d.GenerateRandomBalls(50);
balls.Add(new Ball<TwoDimensionVector>
{
    Mass = 1E10,
    Density = 1E09,
    Position = new TwoDimensionVector() { X = -50, Y = -60 },
    Velocity = new TwoDimensionVector() { X = 0.07, Y = 0 }
});
JobHelper2d.Dump(balls);
//balls = JobHelper2d.Load("crowd_3s.json");

stroboscope.Init(balls);
int i = 0;

var step = 3.0d;

using (var win = new Example())
{
    win.SetStep(step);
    win.AdaptDelegate = () =>
    {
        stroboscope.Step(step);
        win.Adapt(balls);
        
        i++;
    };
    win.Run();
}