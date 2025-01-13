namespace ShootEmUp
{
    public interface IBulletSpawner
    {
        void SpawnBullet(BulletConfig config, BulletArgs args);
    }
}