using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour, IPauseable
    {
        public event Action SpacePressed;
        public event Action<Vector2> DirectionKeyPressed;

        public bool IsPaused { get; set; }

        private void Update()
        {
            if (IsPaused) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpacePressed?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                DirectionKeyPressed?.Invoke(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                DirectionKeyPressed?.Invoke(Vector2.right);
            }
        }
    }
}