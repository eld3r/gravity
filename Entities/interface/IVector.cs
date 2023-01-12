public interface IVector : ICustClonable<IVector>
{
    void Zero();

    bool IsNan();
}