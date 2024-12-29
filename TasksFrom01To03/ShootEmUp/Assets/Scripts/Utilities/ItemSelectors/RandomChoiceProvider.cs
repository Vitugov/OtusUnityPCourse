using System;
using System.Collections.Generic;


namespace ShootEmUp
{
    public sealed class RandomChoiceProvider<T> : IChoiceProvider<T>
    {
        private readonly Random _random;

        public RandomChoiceProvider()
        {
            _random = new Random();
        }

        public T Choose(IReadOnlyList<T> items)
        {
            var index = _random.Next(items.Count);
            return items[index];
        }
    }
}
