using NSubstitute;
using NUnit.Framework;

namespace Asteroids
{
    public class TorqueMotorTests
    {
        [TestCase(1, 100f)]
        [TestCase(-1, -100f)]
        public void GivenADirection100TurnSpeedAnd1Second_WhenGetNextFrameRotation_ThenShouldBeTheExpectedResult(
            float direction, float expectedResult)
        {
            const int turnSpeed = 100;
            var docMotorProvider = Substitute.For<MotorStatsProvider>();
            docMotorProvider.GetTurnSpeed().ReturnsForAnyArgs(turnSpeed);
            var sut = new TorqueMotor();
            sut.SetStatsProvider(docMotorProvider);

            var deltaTime = 1f;
            var result = sut.GetNextFrameRotation(direction, deltaTime);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}