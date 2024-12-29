using System;

namespace ShootEmUp
{
    public interface IGameButton
    {
        event Action OnClick;

        void OnButtonPressed();
    }
}