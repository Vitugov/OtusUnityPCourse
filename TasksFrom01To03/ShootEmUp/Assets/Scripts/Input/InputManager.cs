using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField] CoroutineManager _coroutineManager;
        ICoroutineHandler _coroutineHandler;
        
        public event Action SpacePressed;
        public event Action<Vector2> DirectionKeyPressed;

        private void Start()
        {
            var coroutineLogic = new ActionCoroutineLogic<InputManager>(InputStep);
            _coroutineHandler = _coroutineManager.GetCoroutineHandler(coroutineLogic, this);
            _coroutineManager.StartCoroutine(_coroutineHandler);
        }

        private void InputStep(InputManager inputManager)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inputManager.SpacePressed?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputManager.DirectionKeyPressed?.Invoke(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                inputManager.DirectionKeyPressed?.Invoke(Vector2.right);
            }
        }
    }
}