using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace Asteroids
{
    public class MovementMotorTests
    {
        [Test]
        public void GivenMotorAndNoDirection_WhenGetNextFrameForce_ThenShouldBe0()
        {
            var doc = Substitute.For<MovementStatsProvider>();
            var sut = new MovementMotor();
            sut.SetStatsProvider(doc);

            var result = sut.GetNextFrameForce(Vector2.zero);

            var expectedResult = Vector2.zero;
            Assert.That(result.Equals(expectedResult), $"expected result: {expectedResult} result: {result}");
        }

        [Test]
        public void GivenDirectionAndAcceleration_WhenGetNextFrameForce_ThenShouldBeTheExpectedResult()
        {
            const float acceleration = 10f;
            var docMotorProvider = Substitute.For<MovementStatsProvider>();
            docMotorProvider.GetAcceleration().Returns(acceleration);
            var sut = new MovementMotor();
            sut.SetStatsProvider(docMotorProvider);

            var direction = new Vector2(1, 1);
            var result = sut.GetNextFrameForce(direction).ToString("F2");

            var expectedResult = new Vector2(7.07f, 7.07f).ToString("F2");
            Assert.That(result.Equals(expectedResult), $"expected result: {expectedResult} result: {result}");
        }


        [Test]
        public void GivenAPositiveSurplusVelocity_WhenClampToMaxSpeedVelocity_ThenShouldBeTheMaxVelocity()
        {
            const int maxSpeed = 10;
            var docMotorProvider = Substitute.For<MovementStatsProvider>();
            docMotorProvider.GetMaxSpeed().ReturnsForAnyArgs(maxSpeed);
            var sut = new MovementMotor();
            sut.SetStatsProvider(docMotorProvider);

            var currentVelocity = new Vector2(maxSpeed + 1, maxSpeed + 1);
            var result = sut.ClampToMaxSpeedVelocity(currentVelocity);

            var expectedResult = new Vector2(maxSpeed, maxSpeed);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GivenANegativeSurplusVelocity_WhenClampToMaxSpeedVelocity_ThenShouldBeTheMaxVelocity()
        {
            const int maxSpeed = 10;
            var docMotorProvider = Substitute.For<MovementStatsProvider>();
            docMotorProvider.GetMaxSpeed().ReturnsForAnyArgs(maxSpeed);
            var sut = new MovementMotor();
            sut.SetStatsProvider(docMotorProvider);

            var currentVelocity = new Vector2(-maxSpeed - 1, -maxSpeed - 1);
            var result = sut.ClampToMaxSpeedVelocity(currentVelocity);

            var expectedResult = new Vector2(-maxSpeed, -maxSpeed);
            Assert.That(result, Is.EqualTo(expectedResult));
        }


    }
}