namespace Strobing.Combinators;

//TODO better algo
[Obsolete]
public class DoublePassCombinator<T> : ICombinator<T>
    where T : class
{
    List<KeyValuePair<T, T>> combos = new List<KeyValuePair<T, T>>();
    public void Combine(List<T> items, Action<T, T> action)
    {
        combos.Clear();
        foreach (T item in items)
        {            
            foreach (T inner in items)
            {
                if (item == inner)
                    continue;

                if (combos.Any(a => a.Value == item && a.Key == inner ||
                                    a.Value == inner && a.Key == item))
                    continue;

                action(item, inner);
                combos.Add(KeyValuePair.Create(inner, item));
            }
        }
    }

    public void Enumerate(List<T> balls, Action<T> action)
    {
        foreach(T ball in balls)
        {
            action(ball);
        }
    }
}
