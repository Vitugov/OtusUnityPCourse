using UnityEngine;


namespace ShootEmUp
{
    public sealed class CharacterInitializer : MonoBehaviour
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletManager _bulletManager;

        public void Initialize(Character character)
        {
            character.Initialize(_levelBounds, _bulletManager);
        }
    }
}
