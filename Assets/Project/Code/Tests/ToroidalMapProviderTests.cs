using NSubstitute;
using NUnit.Framework;

namespace Asteroids
{
    public class ToroidalMapProviderTests
    {
        [Test]
        public void GivenAspectRationAndOrthographicSize_WhenGetMap_ThenTheWidthShouldBeTheExpectedHeight()
        {
            var doc = Substitute.For<EngineCameraContext>();
            doc.GetAspectRatio().ReturnsForAnyArgs(1.5f);
            doc.GetOrthographicSize().ReturnsForAnyArgs(5f);
            var sut = new ToroidalMapProvider(doc);

            var map = sut.GetMap();
            var width = map.GetWidth();

            var expectedWidth = 15f;
            Assert.That(width, Is.EqualTo(expectedWidth));
        }
        
        [Test]
        public void GivenAspectRationAndOrthographicSize_WhenGetMap_ThenTheHeightShouldBeTheExpectedHeight()
        {
            var doc = Substitute.For<EngineCameraContext>();
            doc.GetAspectRatio().ReturnsForAnyArgs(1.5f);
            doc.GetOrthographicSize().ReturnsForAnyArgs(5f);
            var sut = new ToroidalMapProvider(doc);

            var map = sut.GetMap();
            var height = map.GetHeight();

            var expectedHeight = 10f;
            Assert.That(height, Is.EqualTo(expectedHeight));
        }
    }
}