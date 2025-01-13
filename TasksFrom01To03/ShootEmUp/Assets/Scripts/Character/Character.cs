using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Character : MonoBehaviour, IResettable
    {
        public event Action OnDeath;

        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private MoveWithRestrictions _moveWithRestrictions;

        private CharacterData _characterInitialData;

        public void Initialize(IRestrictor restrictor, BulletManager bulletManager)
        {
            _moveWithRestrictions.Initialize(restrictor);
            _weaponComponent.Initialize(bulletManager);
            SaveCharacterInitialState();
            _hitPointsComponent.HpEmpty += OnCharacterDeath;
        }

        void IResettable.Reset()
        {
            LoadCharacterInitialState();
        }

        public void Deinitialize()
        {
            _hitPointsComponent.HpEmpty -= OnCharacterDeath;
        }

        public void Move(Vector2 direction)
        {
            _moveWithRestrictions.Move(direction);
        }

        public void Fire()
        {
            _weaponComponent.Fire();
        }

        private void OnCharacterDeath(GameObject _)
        {
            OnDeath?.Invoke();
        }

        private void SaveCharacterInitialState()
        {
            _characterInitialData = new CharacterData(_hitPointsComponent.HitPoints, transform.position);
        }

        private void LoadCharacterInitialState()
        {
            _hitPointsComponent.HitPoints = _characterInitialData.HitPoints;
            transform.position = _characterInitialData.Position;
        }
    }
}
