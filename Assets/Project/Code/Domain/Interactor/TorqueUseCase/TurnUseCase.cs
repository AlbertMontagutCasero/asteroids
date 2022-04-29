namespace Asteroids
{
    public class TurnUseCase : Service
    {
        private readonly TorqueMotor motor;

        public TurnUseCase()
        {
            this.motor = new TorqueMotor();
        }

        public void Turn(Rotator rotator, float turnDirection, float delta)
        {
            var statsProvider = rotator.GetStatsProvider();
            this.motor.SetStatsProvider(statsProvider);

            var nextFrameRotation = this.motor.GetNextFrameRotation(turnDirection, delta);
            rotator.Rotate(nextFrameRotation);
        }
    }
}