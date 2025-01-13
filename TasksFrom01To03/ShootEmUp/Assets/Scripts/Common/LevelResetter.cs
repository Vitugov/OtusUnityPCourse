using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelResetter : MonoBehaviour
    {
        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private Character _character;

        public void ResetLevel()
        {
            var resettables = new IResettable[] { _bulletManager, _enemyManager, _character };

            foreach (var resettable in resettables)
            {
                resettable.Reset();
            }
        }
    }
}
