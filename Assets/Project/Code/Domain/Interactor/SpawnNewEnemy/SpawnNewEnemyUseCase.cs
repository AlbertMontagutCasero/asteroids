namespace Asteroids
{
    public class SpawnNewEnemyUseCase: Service
    {
        private readonly EnemySpawnerConfiguration enemySpawnerConfiguration;
        private readonly EnemySpawner enemySpawner;
        private float totalTimeElapsedSinceLastSpawn;

        public SpawnNewEnemyUseCase(EnemySpawnerConfiguration enemySpawnerConfiguration, EnemySpawner enemySpawner)
        {
            this.enemySpawnerConfiguration = enemySpawnerConfiguration;
            this.enemySpawner = enemySpawner;
        }

        public void AddTime(float secondsElapsed)
        {
            this.totalTimeElapsedSinceLastSpawn += secondsElapsed;
            while (this.totalTimeElapsedSinceLastSpawn >= this.enemySpawnerConfiguration.GetSpawnTime())
            {
                this.totalTimeElapsedSinceLastSpawn -= this.enemySpawnerConfiguration.GetSpawnTime();
                this.enemySpawner.SpawnEnemy();
            }
        }
    }
}