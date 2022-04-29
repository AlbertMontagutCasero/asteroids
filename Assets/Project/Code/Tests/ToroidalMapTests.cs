using NUnit.Framework;
using UnityEngine;

namespace Asteroids
{
    public class ToroidalMapTests
    {
        [Test]
        public void GivenMapSize_WhenGetBottom_ThenShouldBeTheExpectedResult()
        {
            var sut = new ToroidalMap(20, 10);

            var result = sut.GetBottom();

            var expectedResult = -5;
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void GivenMapSize_WhenGetRight_ThenShouldBeTheExpectedResult()
        {
            var sut = new ToroidalMap(20, 10);

            var result = sut.GetRight();

            var expectedResult = 10;
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void GivenMapSize_WhenGetTop_ThenShouldBeTheExpectedResult()
        {
            var sut = new ToroidalMap(20, 10);

            var result = sut.GetTop();

            var expectedResult = 5;
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void GivenMapSize_WhenGetLeft_ThenShouldBeTheExpectedResult()
        {
            var sut = new ToroidalMap(20, 10);

            var result = sut.GetLeft();

            var expectedResult = -10;
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void GivenAPositionOutsideFromRightSide_WhenCalculateToroidalPosition_ThenShouldReturnLeftPosition()
        {
            var sut = new ToroidalMap(20, 10);
            var result = sut.CalculateToroidalPosition(new Vector2(10.01f, 0));

            var expectedResult = new Vector2(-10f, 0);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void GivenAPositionWithin_WhenCalculateToroidalPosition_ThenShouldReturnTheSamePosition()
        {
            var sut = new ToroidalMap(20, 10);
            var result = sut.CalculateToroidalPosition(new Vector2(10f, 0));

            var expectedResult = new Vector2(10f, 0);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void GivenAPositionOutsideBottom_WhenCalculateToroidalPosition_ThenShouldReturnTheTopPosition()
        {
            var sut = new ToroidalMap(20, 10);
            var result = sut.CalculateToroidalPosition(new Vector2(0, -5.000001f));

            var expectedResult = new Vector2(0, 5);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}