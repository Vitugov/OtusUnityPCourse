using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class RandomItemSelector<TItem>
    {
        private readonly IChoiceProvider<TItem> _choiceProvider;
        private readonly IReadOnlyList<TItem> _items;

        public RandomItemSelector(IEnumerable<TItem> items, IChoiceProvider<TItem> choiceProvider)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            _items = new List<TItem>(items);
            _choiceProvider = choiceProvider ?? throw new ArgumentNullException(nameof(choiceProvider));
        }

        public TItem GetRandomItem()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("No items available for selection.");
            }

            return _choiceProvider.Choose(_items);
        }
    }
}
