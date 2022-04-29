namespace Asteroids
{
    public class ToroidalMapProvider
    {
        private readonly EngineCameraContext engineCameraContext;

        public ToroidalMapProvider(EngineCameraContext engineCameraContext)
        {
            this.engineCameraContext = engineCameraContext;
        }
    
        public ToroidalMap GetMap()
        {
            var height = this.GetVisibleHeightUnits();
            var width = this.GetVisibleWidthUnits();

            return new ToroidalMap(width, height);
        }

        private float GetVisibleHeightUnits()
        {
            return  2 * this.engineCameraContext.GetOrthographicSize();
        }

        private float GetVisibleWidthUnits()
        {
            return this.GetVisibleHeightUnits() * this.engineCameraContext.GetAspectRatio();
        }
    }
}