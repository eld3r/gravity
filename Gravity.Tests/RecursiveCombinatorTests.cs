using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Strobing.Combinators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Gravity.Tests
{
    [TestClass]
    public class RecursiveCombinatorTests
    {
        static ICombinator<object> target;

        [ClassInitialize]
        public static void ClassInit(TestContext ctx)
        {
            target = new RecursiveCombinator<object>();
        }

        [TestMethod]
        public void CountCombos()
        {
            List<object> list = new List<object>() { 1,2,3 };
            
            int count = 0;

            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();

            target.Combine(list, (obj, obj1) =>
            {
                result.Add(KeyValuePair.Create((int)obj, (int)obj1));
            });

            result.Count.ShouldBe(3);
            result.ShouldContain(k => k.Key == 1 || k.Value == 1);
            result.ShouldContain(k => k.Key == 2 || k.Value == 2);
            result.ShouldContain(k => k.Key == 3 || k.Value == 3);

            result.ShouldContain(k => (k.Key == 3 && k.Value == 1) || (k.Key == 1 && k.Value == 3));
            result.ShouldContain(k => (k.Key == 2 && k.Value == 1) || (k.Key == 1 && k.Value == 2));
            result.ShouldContain(k => (k.Key == 3 && k.Value == 2) || (k.Key == 2 && k.Value == 3));

            result.ShouldNotContain(k => (k.Key == k.Value));
        }

        [TestMethod]
        public void CheckTime()
        {
            List<object> list = Enumerable.Range(0, 1000).Cast<object>().ToList();

            int count = 0;

            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            target.Combine(list, (obj, obj1) =>
            {
                Math.Pow(0.1, 0.1);
                result.Add(KeyValuePair.Create((int)obj, (int)obj1));
            });
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());

            result.Count.ShouldBe(499500);
            result.ShouldContain(k => k.Key == 1 || k.Value == 1);
            result.ShouldContain(k => k.Key == 2 || k.Value == 2);
            result.ShouldContain(k => k.Key == 3 || k.Value == 3);

            result.ShouldContain(k => (k.Key == 3 && k.Value == 1) || (k.Key == 1 && k.Value == 3));
            result.ShouldContain(k => (k.Key == 2 && k.Value == 1) || (k.Key == 1 && k.Value == 2));
            result.ShouldContain(k => (k.Key == 3 && k.Value == 2) || (k.Key == 2 && k.Value == 3));

            result.ShouldNotContain(k => (k.Key == k.Value));
        }

    }
}