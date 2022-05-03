namespace Asteroids
{
    public class ToroidalMovementUseCase : Service
    {
        private readonly ToroidalMap toroidalMap;
        private readonly DomainSignalDispatcher signalDispatcher;
        private readonly MovementMotor motor;
        private readonly MovablePositionUpdatedSignal positionUpdatedSignal;

        public ToroidalMovementUseCase(ToroidalMap map, DomainSignalDispatcher signalDispatcher)
        {
            this.toroidalMap = map;
            this.signalDispatcher = signalDispatcher;
            this.motor = new MovementMotor();
            this.positionUpdatedSignal = new MovablePositionUpdatedSignal();
        }

        public void Move(ToroidalMovable movable)
        {
            this.SetMotorStats(movable);
            this.ApplyForce(movable);
            this.ClampVelocity(movable);
            this.ExecuteMovementByInertia(movable);
        }

        private void ClampVelocity(ToroidalMovable movable)
        {
            var currentVelocity = movable.GetCurrentVelocity();
            var clampedMaxVelocity = this.motor.ClampToMaxSpeedVelocity(currentVelocity);
            movable.ClampMaxSpeed(clampedMaxVelocity);
        }

        private void SetMotorStats(ToroidalMovable movable)
        {
            var statsProvider = movable.GetStatsProvider();
            this.motor.SetStatsProvider(statsProvider);
        }

        private void ApplyForce(ToroidalMovable movable)
        {
            var forwardDirection = movable.GetForwardDirection();

            var nextFrameForce = this.motor.GetNextFrameForce(forwardDirection);
            movable.ApplyForce(nextFrameForce);
        }

        public void ExecuteMovementByInertia(ToroidalMovable movable)
        {
            var positionAfterMoving = movable.GetPosition();
            var finalToroidalPosition = this.toroidalMap.CalculateToroidalPosition(positionAfterMoving);
            movable.SetPosition(finalToroidalPosition);
            
            this.positionUpdatedSignal.Position = finalToroidalPosition;
            this.signalDispatcher.Dispatch(this.positionUpdatedSignal);
        }
    }
}