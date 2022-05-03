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
            var docConfigurationProvider = Substitute.For<HazardSpawnerConfiguration>();
            docConfigurationProvider.GetSpawnTime().ReturnsForAnyArgs(secondsElapsed);
            var docEnemySpawner = Substitute.For<HazardSpawner>();
            
            var sut = new SpawnNewHazardUseCase(docConfigurationProvider, docEnemySpawner);
            sut.AddTime(secondsElapsed);
            
            docEnemySpawner.Received().SpawnEnemy(default);
        }
        
        [Test]
        public void GivenSpawnTime_WhenAddTimeButIsLessThanTheSpawnTime_ThenEnemySpawnerSpawnEnemyShouldNotBeCalled()
        {
            const float secondsElapsed = 1f;
            var docConfigurationProvider = Substitute.For<HazardSpawnerConfiguration>();
            docConfigurationProvider.GetSpawnTime().ReturnsForAnyArgs(secondsElapsed + 0.000001f);
            var docEnemySpawner = Substitute.For<HazardSpawner>();
            
            var sut = new SpawnNewHazardUseCase(docConfigurationProvider, docEnemySpawner);
            sut.AddTime(secondsElapsed);
            
            docEnemySpawner.DidNotReceiveWithAnyArgs().SpawnEnemy(default);
        }

        [Test]
        public void WhenGetAngle_ShouldReturnARandomAngle()
        {
            var doc = Substitute.For<Random>();

            doc.GetFloatBetween(default, default).ReturnsForAnyArgs(30);
            var sut = new Hazard(doc, null);
            var result = sut.GetAngle();

            var expectedAngle = 30;
            Assert.That(result, Is.EqualTo(expectedAngle));
        }
        
        [Test]
        public void GivenAConfiguration_WhenGetSpeed_ShouldReturnASpeedInTheRangeOfTheConfiguration()
        {
            //Arrange
            const int minSpeed = 5;
            const int maxSpeed = 10;
            var doc = Substitute.For<Random>();
            doc.GetFloatBetween(minSpeed, maxSpeed).ReturnsForAnyArgs(minSpeed);
            
            var docConfiguration = Substitute.For<HazardConfiguration>();
            docConfiguration.GetMaxSpeed().ReturnsForAnyArgs(maxSpeed);
            docConfiguration.GetMinSpeed().ReturnsForAnyArgs(minSpeed);
            
            //Act
            var sut = new Hazard(doc, docConfiguration);
            var result = sut.GetSpeed();

            //Assert
            var expectedSpeed = 5;
            Assert.That(result, Is.EqualTo(expectedSpeed));
        }
    }
}