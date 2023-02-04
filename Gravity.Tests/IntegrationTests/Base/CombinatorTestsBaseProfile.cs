using Gravity.Tests.IntegrationTests.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Strobing.Combinators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Gravity.Tests.IntegrationTests;

[TestClass]
public class CombinatorTestsBaseProfile<T> : ServicesBaseProfile
    where T : class, new()
{
    [ClassInitialize(InheritanceBehavior.BeforeEachDerivedClass)]
    public static void ClassInit(TestContext tc)
    {
        Target = Services.GetRequiredService<ICombinator<T>>();
    }

    private static ICombinator<T> Target { get; set; } = null!;

    [TestMethod]
    public void CountCombos()
    {
        T o1 = new T();
        T o2 = new T();
        T o3 = new T();

        List<T> list = new List<T>() { o1, o2, o3 };

        int count = 0;

        List<KeyValuePair<T, T>> result = new List<KeyValuePair<T, T>>();

        Target.Combine(list, (obj, obj1) =>
        {
            result.Add(KeyValuePair.Create(obj, obj1));
        });

        result.Count.ShouldBe(3);
        result.ShouldContain(k => k.Key == o1 || k.Value == o1);
        result.ShouldContain(k => k.Key == o2 || k.Value == o2);
        result.ShouldContain(k => k.Key == o3 || k.Value == o3);

        result.ShouldContain(k => (k.Key == o3 && k.Value == o1) || (k.Key == o1 && k.Value == o3));
        result.ShouldContain(k => (k.Key == o2 && k.Value == o1) || (k.Key == o1 && k.Value == o2));
        result.ShouldContain(k => (k.Key == o3 && k.Value == o2) || (k.Key == o2 && k.Value == o3));

        result.ShouldNotContain(k => (k.Key == k.Value));
    }

    [TestMethod]
    public void CheckTime()
    {
        var N = 200;

        List<T> list = Enumerable.Range(0, N).Select(s=> new T()).ToList();

        List<KeyValuePair<T, T>> result = new List<KeyValuePair<T, T>>();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Target.Combine(list, (obj, obj1) =>
        {
            Math.Pow(0.1, 0.1);
            result.Add(KeyValuePair.Create(obj, obj1));
        });
        sw.Stop();
        Console.WriteLine(sw.Elapsed.ToString());

        result.Count.ShouldBe(CountCombos(N));
        sw.Elapsed.ShouldBeLessThan(TimeSpan.FromMilliseconds(4));

        result.ShouldNotContain(k => (k.Key == k.Value));
    }

    private int CountCombos(int n, int q = 2)
    {
        var ch = Enumerable.Range(1, n);
        var zn = Enumerable.Range(1, n-q);

        return ch.Except(zn).Aggregate(1, (a, b) => b = a * b) / 2;
    }
}
