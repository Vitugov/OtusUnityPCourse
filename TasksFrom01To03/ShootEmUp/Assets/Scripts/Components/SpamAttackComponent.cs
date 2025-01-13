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
            _target = target;
            _targetHitPoints = target.GetComponent<IHitPoints>();
            _fireHandler = GetFireHandler(_coroutineManager);
        }

        public void StartFire() => _coroutineManager.StartCoroutine(_fireHandler); 

        public void StopFire() => _coroutineManager.StopCoroutineIfRunning(_fireHandler);

        private void Fire() => FireEvent?.Invoke(_target.transform);

        private ICoroutineHandler GetFireHandler(CoroutineManager coroutineManager)
        {
            var logic = new ConditionalCoroutineLogic<IHitPoints>(ShouldFire, _countdown, Fire, false);
            return coroutineManager.GetCoroutineHandler(logic, _targetHitPoints);

            bool ShouldFire(IHitPoints hitPointsComponent) => hitPointsComponent.IsHitPointsExists();
        }
    }
}