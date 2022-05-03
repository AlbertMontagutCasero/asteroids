namespace Asteroids
{
    public interface HazardSpawnerConfiguration: HazardConfiguration
    {
        float GetSpawnTime();
    }
}