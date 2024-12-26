using UnityEngine;


namespace ShootEmUp
{
    public class PoolInstancer<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;
        [SerializeField] private T prefab;
        [SerializeField] private Transform container;
        [SerializeField] private Transform worldTransform;

        public Pool<T> GetPool()
        {
            var pool = new Pool<T>(prefab, container, worldTransform);
            pool.FullFill(initialCount);
            return pool;
        }
    }
}
