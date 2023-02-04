namespace Strobing.Combinators;

public interface ICombinator<T>
{
    void Combine(List<T> items, Action<T,T> action);

    void Enumerate(List<T> balls, Action<T> p);
}