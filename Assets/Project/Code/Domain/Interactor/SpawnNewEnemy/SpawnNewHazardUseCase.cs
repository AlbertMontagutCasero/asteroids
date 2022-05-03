namespace Asteroids
{
    public class SpawnNewHazardUseCase: Service
    {
        private readonly HazardSpawnerConfiguration hazardSpawnerConfiguration;
        private readonly HazardSpawner hazardSpawner;
        private float totalTimeElapsedSinceLastSpawn;
        private readonly Hazard hazard;

        public SpawnNewHazardUseCase(HazardSpawnerConfiguration hazardSpawnerConfiguration, HazardSpawner hazardSpawner)
        {
            this.hazardSpawnerConfiguration = hazardSpawnerConfiguration;
            this.hazardSpawner = hazardSpawner;
            this.hazard = new Hazard(new RandomUnity(), hazardSpawnerConfiguration);
        }

        public void AddTime(float secondsElapsed)
        {
            this.totalTimeElapsedSinceLastSpawn += secondsElapsed;
            while (this.totalTimeElapsedSinceLastSpawn >= this.hazardSpawnerConfiguration.GetSpawnTime())
            {
                this.totalTimeElapsedSinceLastSpawn -= this.hazardSpawnerConfiguration.GetSpawnTime();
                this.hazardSpawner.SpawnEnemy(this.hazard);
            }
        }
    }
}