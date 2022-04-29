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
            var statsProvider = movable.GetStatsProvider();
            this.motor.SetStatsProvider(statsProvider);

            var forwardDirection = movable.GetForwardDirection();

            var nextFrameForce = this.motor.GetNextFrameForce(forwardDirection);
            movable.ApplyForce(nextFrameForce);

            var currentVelocity = movable.GetCurrentVelocity();
            var clampedMaxVelocity = this.motor.ClampToMaxSpeedVelocity(currentVelocity);
            movable.ClampMaxSpeed(clampedMaxVelocity);
            
            this.ExecuteMovementByInertia(movable);
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