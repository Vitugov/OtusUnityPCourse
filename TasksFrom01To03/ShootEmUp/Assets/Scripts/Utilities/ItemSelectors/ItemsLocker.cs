using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootEmUp
{
    public sealed class ItemsLocker<TOwner, TItem>
    {
        private readonly IReadOnlyList<TItem> _originalItems;
        private readonly List<TItem> _freeItems;
        private readonly Dictionary<TOwner, TItem> _lockedOwnersItems;
        private readonly IChoiceProvider<TItem> _choiceProvider;

        public int FreeItemsCount => _freeItems.Count;

        public ItemsLocker(IEnumerable<TItem> items, IChoiceProvider<TItem> choiceProvider)
        {
            _freeItems = items.ToList();
            _originalItems = _freeItems.AsReadOnly();
            _lockedOwnersItems = new Dictionary<TOwner, TItem>();
            _choiceProvider = choiceProvider ?? throw new ArgumentNullException(nameof(choiceProvider));
        }

        public void Release(TOwner owner)
        {
            if (!_lockedOwnersItems.Remove(owner, out var item))
            {
                throw new InvalidOperationException($"Owner {owner} is not currently locking any item.");
            }
            _freeItems.Add(item);
        }

        public TItem GetAndLock(TOwner owner)
        {
            if (_lockedOwnersItems.ContainsKey(owner))
            {
                throw new InvalidOperationException($"Owner {owner} already has a locked item.");
            }
            if (_freeItems.Count == 0)
            {
                throw new InvalidOperationException("No free items available.");
            }

            var item = _choiceProvider.Choose(_freeItems);
            _lockedOwnersItems.Add(owner, item);
            _freeItems.Remove(item);

            return item;
        }

        public void Clear()
        {
            _lockedOwnersItems.Clear();
            _freeItems.Clear();
            _freeItems.AddRange(_originalItems);
        }
    }
}
