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
            var reloadables = new IReloadable[] {_bulletManager, _enemyManager, _character};
            
            foreach (var reloadable in reloadables)
            {
                reloadable.Reload();
            }
        }
    }
}
