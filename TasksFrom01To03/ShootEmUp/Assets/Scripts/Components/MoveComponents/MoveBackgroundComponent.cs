using UnityEngine;

namespace ShootEmUp
{
    public class MoveBackgroundComponent
    {
        private readonly IBackgroundParameters _parameters;
        private readonly float _positionX;
        private readonly float _positionZ;

        public MoveBackgroundComponent(IBackgroundParameters parameters, float positionX, float positionZ)
        {
            _parameters = parameters;
            _positionX = positionX;
            _positionZ = positionZ;
        }

        public void Move(Transform transform)
        {
            if (transform.position.y <= _parameters.EndPositionY)
            {
                transform.position = new Vector3(_positionX, _parameters.StartPositionY, _positionZ);
            }

            transform.position -= new Vector3(0, _parameters.MovingSpeedY * Time.fixedDeltaTime, 0);
        }
    }
}
