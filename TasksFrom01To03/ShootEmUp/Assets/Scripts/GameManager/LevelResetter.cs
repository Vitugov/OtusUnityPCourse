using UnityEngine;

namespace ShootEmUp
{
    public class LevelResetter : MonoBehaviour
    {
        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private Character _character;

        public void ResetLevel()
        {
            _bulletManager.RemoveAllBullets();
            _enemyManager.UnspawnAll();
            _character.LoadCharacterInitialState();
        }
    }
}
