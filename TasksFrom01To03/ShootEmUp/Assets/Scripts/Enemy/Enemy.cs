﻿using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class Enemy : MonoBehaviour
    {
        public event Action<Enemy> HpEmpty;

        [SerializeField] private MoveToDestinationComponent _moveToDestinationComponent;
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private SpamAttackComponent _spamAttackComponent;
        [SerializeField] private WeaponComponent _weaponComponent;

        public void Initialize(IBulletSpawner bulletManager, GameObject target, Vector2 spawnPosition, Vector2 attackPosition)
        {
            transform.position = spawnPosition;
            _weaponComponent.Initialize(bulletManager);
            _spamAttackComponent.Initialize(target);
            _moveToDestinationComponent.SetDestination(attackPosition);

            _moveToDestinationComponent.DestinationIsReachedEvent += _spamAttackComponent.StartFire;
            _spamAttackComponent.FireEvent += _weaponComponent.Fire;
            _hitPointsComponent.HpEmpty += OnHpEmpty;

            _moveToDestinationComponent.StartMove();
        }

        public void DeInitialize()
        {
            _moveToDestinationComponent.StopMove();
            _spamAttackComponent.StopFire();

            _spamAttackComponent.FireEvent -= _weaponComponent.Fire;
            _moveToDestinationComponent.DestinationIsReachedEvent -= _spamAttackComponent.StartFire;
            _hitPointsComponent.HpEmpty -= OnHpEmpty;
        }

        private void OnHpEmpty(GameObject gameObject) => HpEmpty?.Invoke(this);
    }
}
