using UnityEngine;

namespace ShootEmUp
{
    public sealed class DamagerComponent : MonoBehaviour
    {
        private int _damage = 1;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        public void DealDamage(GameObject target)
        {
            if (target.TryGetComponent(out ITeamable targetTeam) && TryGetComponent(out ITeamable sourceTeam))
            {
                if (sourceTeam.IsTheSameTeam(targetTeam))
                    return;
            }

            if (target.TryGetComponent(out IHitPoints damageableTarget))
            {
                damageableTarget.TakeDamage(_damage);
            }
        }
    }
}
