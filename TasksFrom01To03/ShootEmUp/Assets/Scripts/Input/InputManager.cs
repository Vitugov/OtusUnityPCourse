using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public event Action SpacePressed;
        public event Action<Vector2> DirectionKeyPressed;

        private void Update()
        {
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