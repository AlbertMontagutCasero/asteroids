namespace Asteroids
{
    public class AccelerationMovementUseCase: Service
    {
        private readonly MovementMotor motor;

        public AccelerationMovementUseCase()
        {
            this.motor = new MovementMotor();
        }

        public void Move(MovableWithAcceleration movable)
        {
            this.SetMotorStats(movable);
            this.ApplyForce(movable);
            this.ClampVelocity(movable);
        }

        private void ClampVelocity(MovableWithAcceleration movable)
        {
            var currentVelocity = movable.GetCurrentVelocity();
            var clampedMaxVelocity = this.motor.ClampToMaxSpeedVelocity(currentVelocity);
            movable.ClampMaxSpeed(clampedMaxVelocity);
        }

        private void SetMotorStats(MovableWithAcceleration movable)
        {
            var statsProvider = movable.GetStatsProvider();
            this.motor.SetStatsProvider(statsProvider);
        }

        private void ApplyForce(MovableWithAcceleration movable)
        {
            var forwardDirection = movable.GetForwardDirection();

            var nextFrameForce = this.motor.GetNextFrameForce(forwardDirection);
            movable.ApplyForce(nextFrameForce);
        }
    }
}