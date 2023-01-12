namespace Strobing.Combinators;

public class RecursiveCombinator<T> : ICombinator<T>
where T : class
{
    public void Combine(List<T> items, Action<T, T> action)
    {
        CombineRecurse(items, action);
    }

    private void CombineRecurse(IEnumerable<T> items, Action<T, T> action)
    {
        if (!items.Any())
            return;
        var first = items.First();
        var skipped = items.Skip(1);
        foreach (var item in skipped)
        {
            action(first, item);
        }

        CombineRecurse(skipped, action);
    }

    public void Enumerate(List<T> balls, Action<T> action)
    {
        foreach (T ball in balls)
        {
            action(ball);
        }
    }
}
