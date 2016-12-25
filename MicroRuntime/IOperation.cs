namespace Microruntime
{
    public interface IOperation<T>
    {
        T Add(T t);
        T Substract(T t);
    }
}