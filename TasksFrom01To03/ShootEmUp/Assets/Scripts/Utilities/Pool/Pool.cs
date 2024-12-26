using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootEmUp
{
    public sealed class Pool<T> where T : Component
    {
        private readonly Queue<T> _poolObjects;
        private readonly HashSet<T> _ativeObjects;
        private readonly Transform _poolRoot;
        private readonly Transform _worldRoot;
        private readonly T _prefab;
        public int ActiveObjectsCount => _ativeObjects.Count;

        public Pool(T prefab, Transform poolRootTransform, Transform worldRootTransform)
        {
            _prefab = prefab;
            _poolRoot = poolRootTransform;
            _worldRoot = worldRootTransform;
            _poolObjects = new Queue<T>();
            _ativeObjects = new HashSet<T>();
        }

        public IReadOnlyCollection<T> GetActiveObjects() => _ativeObjects;

        public T Get()
        {
            if (_poolObjects.Count == 0)
            {
                return Object.Instantiate(_prefab, _worldRoot);
            }

            var item = _poolObjects.Dequeue();
            _ativeObjects.Add(item);
            item.transform.SetParent(_worldRoot);
            item.gameObject.SetActive(true);
            return item;
        }

        public void Release(T item)
        {
            item.transform.SetParent(_poolRoot);
            item.gameObject.SetActive(false);
            _ativeObjects.Remove(item);
            _poolObjects.Enqueue(item);
        }

        public void FullFill(int objectsNumber)
        {
            for (int i = 0; i < objectsNumber; i++)
            {
                var obj = Object.Instantiate(_prefab, _poolRoot);
                obj.gameObject.SetActive(false);
                _poolObjects.Enqueue(obj);
            }
        }
    }

}
