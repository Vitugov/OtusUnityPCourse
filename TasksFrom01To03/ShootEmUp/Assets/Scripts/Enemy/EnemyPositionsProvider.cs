using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositionsProvider : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositionSet;
        [SerializeField] private Transform[] _attackPositionSet;

        public RandomItemSelector<Vector2> Spawn { get; private set; }
        public ItemsLocker<GameObject, Vector2> Attack { get; private set; }

        private void Awake()
        {
            Spawn = new RandomItemSelector<Vector2>(
                GetPositionArray(_spawnPositionSet),
                new RandomChoiceProvider<Vector2>()
            );

            Attack = new ItemsLocker<GameObject, Vector2>(
                GetPositionArray(_attackPositionSet),
                new RandomChoiceProvider<Vector2>()
            );
        }

        private Vector2[] GetPositionArray(Transform[] positionSet)
        {
            return positionSet.Select(t => (Vector2)t.position).ToArray();
        }
    }
}