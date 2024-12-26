using System.Collections.Generic;


namespace ShootEmUp
{
    public interface IChoiceProvider<T>
    {
        T Choose(IReadOnlyList<T> items);
    }
}
