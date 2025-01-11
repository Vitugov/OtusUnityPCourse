using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class SpamAttackComponent : MonoBehaviour
    {
        public event Action<Transform> FireEvent;

        [SerializeField] private float _countdown;

        private CoroutineManager _coroutineManager;
        private GameObject _target;
        private IHitPoints _targetHitPoints;
        private ICoroutineHandler _fireHandler;

        public void Initialize(CoroutineManager coroutineManager, GameObject target)
        {
            _coroutineManager = coroutineManager;
            ChangeTarget(target);
            CreateFireHandler(_coroutineManager);
        }

        public void ChangeTarget(GameObject target)
        {
            _target = target;
            _targetHitPoints = target.GetComponent<IHitPoints>();
        }

        public void StartFire() => _coroutineManager.StartCoroutine(_fireHandler, gameObject);

        public void StopFire() => _coroutineManager.StopCoroutine(_fireHandler);

        private void Fire() => FireEvent?.Invoke(_target.transform);

        private void CreateFireHandler(CoroutineManager coroutineManager)
        {
            var logic = new ConditionalCoroutineLogic(ShouldFire, _countdown, Fire, false);
            _fireHandler = coroutineManager.GetCoroutineHandler(logic);
        }

        private bool ShouldFire(GameObject gameObject) => _targetHitPoints.IsHitPointsExists();
    }
}