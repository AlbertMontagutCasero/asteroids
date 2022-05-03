namespace Asteroids
{
    public class ToroidalMovementUseCase : Service
    {
        private readonly ToroidalMap toroidalMap;

        public ToroidalMovementUseCase(ToroidalMap toroidalMap)
        {
            this.toroidalMap = toroidalMap;
        }

        public void ExecuteMovementByInertia(ToroidalMovable movable)
        {
            var positionAfterMoving = movable.GetPosition();
            var finalToroidalPosition = this.toroidalMap.CalculateToroidalPosition(positionAfterMoving);
            movable.SetPosition(finalToroidalPosition);
        }
    }
}