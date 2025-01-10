using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class SpamAttackComponent : MonoBehaviour
    {
        public event Action<Transform> FireEvent;

        [SerializeField] private float _countdown;

        private GameObject _target;
        private IHitPoints _targetHitPoints;
        private ConditionalCoroutineHandler _fireHandler;

        public void Initialize(GameObject target)
        {
            ChangeTarget(target);
            CreateFireHandler();
        }

        public void ChangeTarget(GameObject target)
        {
            _target = target;
            _targetHitPoints = target.GetComponent<IHitPoints>();
        }

        public void StartFire() => _fireHandler?.Start(gameObject);

        public void StopFire() => _fireHandler?.Stop();

        private void Fire() => FireEvent?.Invoke(_target.transform);

        private bool ShouldFire(GameObject gameObject) => _targetHitPoints.IsHitPointsExists();

        private void CreateFireHandler()
        {
            _fireHandler = new ConditionalCoroutineHandler(this, ShouldFire, _countdown, Fire, false);
        }
    }
}