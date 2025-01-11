namespace ShootEmUp
{
    public interface IBulletSpawner
    {
        void CreateBullet(BulletConfig config, BulletArgs args);
    }
}