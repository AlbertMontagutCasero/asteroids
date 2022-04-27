using UnityEngine;

namespace Asteroids
{
    public class MovementMotor
    {
        private readonly MotorStatsProvider statsProvider;

        public MovementMotor(MotorStatsProvider statsProvider)
        {
            this.statsProvider = statsProvider;
        }

        public Vector2 GetNextFrameForce(Vector2 direction)
        {
            var acceleration = this.statsProvider.GetAcceleration();
            return direction.normalized * acceleration;
        }

        public Vector2 ClampToMaxSpeedVelocity(Vector2 currentVelocity)
        {
            var maxSpeed = this.statsProvider.GetMaxSpeed();
            var x = Mathf.Clamp(currentVelocity.x, 0, maxSpeed);
            var y = Mathf.Clamp(currentVelocity.y, 0, maxSpeed);
            return new Vector2(x, y);
        }
    }
}