namespace ShootEmUp
{
    public interface ITeamable
    {
        bool IsPlayer { get; }

        bool IsTheSameTeam(ITeamable teamable);
    }
}