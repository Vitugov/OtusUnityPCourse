using UnityEngine;

namespace ShootEmUp
{
    public sealed class TeamComponent : MonoBehaviour, ITeamable
    {
        [SerializeField] private bool _isPlayer;

        public bool IsPlayer
        {
            get => _isPlayer;
            set { _isPlayer = value; }
        }

        public bool IsTheSameTeam(ITeamable teamable)
        {
            return IsPlayer == teamable.IsPlayer;
        }
    }
}