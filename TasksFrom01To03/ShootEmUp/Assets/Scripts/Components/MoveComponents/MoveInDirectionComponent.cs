using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveInDirectionComponent : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;

        private CoroutineManager _coroutineManager;
        private ICoroutineHandler _coroutineHandler;
        
        private DirectionData _directionData;

        public void Initialize(CoroutineManager coroutineManager)
        {
            _coroutineManager = coroutineManager;
            _directionData = new DirectionData(Vector2.zero);
            _coroutineHandler = GetCoroutineHandler(_coroutineManager);
        }

        public void MoveToDirection(Vector2 direction)
        {
            _directionData.Direction = direction;
            _coroutineManager.StartCoroutine(_coroutineHandler);
        }

        public void Stop()
        {
            _coroutineManager.StopCoroutineIfRunning(_coroutineHandler);
        }

        private ICoroutineHandler GetCoroutineHandler(CoroutineManager coroutineManager)
        {
            var coroutineLogic = new ActionCoroutineLogic<MoveInDirectionComponent>(Move);
            var coroutineHandler = coroutineManager.GetCoroutineHandler(coroutineLogic, this);

            return coroutineHandler;

            void Move(MoveInDirectionComponent moveInDirectionComponent)
                => moveInDirectionComponent._moveComponent.MoveInDirection(moveInDirectionComponent._directionData);
        }
    }

    public class DirectionData
    {
        public Vector2 Direction;

        public DirectionData(Vector2 direction) => Direction = direction;
    }
}
