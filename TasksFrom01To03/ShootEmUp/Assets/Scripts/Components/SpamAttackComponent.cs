using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class SpamAttackComponent : MonoBehaviour
    {
        public event Action<Transform> FireEvent;

        [SerializeField] private float _countdown;

        private GameObject _target;
        private ConditionHandler _fireHandler;

        public void Initialize(GameObject target)
        {
            ChangeTarget(target);
            CreateFireHandler();
        }

        public void ChangeTarget(GameObject target) => _target = target;

        public void StartFire() => _fireHandler?.Start(this, gameObject);

        public void StopFire() => _fireHandler?.Stop(this);

        private void Fire() => FireEvent?.Invoke(_target.transform);

        private bool ShouldFire(GameObject obj) => _target.GetComponent<IHitPoints>().IsHitPointsExists();

        private void CreateFireHandler()
        {
            _fireHandler = new ConditionHandler(ShouldFire, _countdown, Fire, false);
        }
    }
}