using NSubstitute;
using NUnit.Framework;

namespace Asteroids
{
    public class EnemySpawnerTests
    {
        [Test]
        public void GivenSpawnTime_WhenAddTimeButIsGreaterThanTheSpawnTime_ThenEnemySpawnerSpawnEnemyShouldBeCalled()
        {
            const float secondsElapsed = 1f;

            var docConfigurationProvider = Substitute.For<EnemySpawnerConfiguration>();
            docConfigurationProvider.GetSpawnTime().ReturnsForAnyArgs(secondsElapsed);
            var docEnemySpawner = Substitute.For<EnemySpawner>();
            var sut = new SpawnNewEnemyUseCase(docConfigurationProvider, docEnemySpawner);
            sut.AddTime(secondsElapsed);
            
            docEnemySpawner.Received().SpawnEnemy();
        }
        
        [Test]
        public void GivenSpawnTime_WhenAddTimeButIsLessThanTheSpawnTime_ThenEnemySpawnerSpawnEnemyShouldNotBeCalled()
        {
            const float secondsElapsed = 1f;

            var docConfigurationProvider = Substitute.For<EnemySpawnerConfiguration>();
            docConfigurationProvider.GetSpawnTime().ReturnsForAnyArgs(secondsElapsed + 0.000001f);
            var docEnemySpawner = Substitute.For<EnemySpawner>();
            var sut = new SpawnNewEnemyUseCase(docConfigurationProvider, docEnemySpawner);
            sut.AddTime(secondsElapsed);
            
            docEnemySpawner.DidNotReceiveWithAnyArgs().SpawnEnemy();
        }
    }
}