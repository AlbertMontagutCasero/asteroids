namespace Asteroids
{
    public class Hazard
    {
        private readonly Random random;
        private readonly HazardConfiguration configuration;

        public Hazard(Random random, HazardConfiguration configuration)
        {
            this.random = random;
            this.configuration = configuration;
        }

        public float GetAngle()
        {
            return this.random.GetFloatBetween(0, 359);
        }

        public float GetSpeed()
        {
            var minSpeed = this.configuration.GetMinSpeed();
            var maxSpeed = this.configuration.GetMaxSpeed();

            return this.random.GetFloatBetween(minSpeed, maxSpeed);
        }
    }
}