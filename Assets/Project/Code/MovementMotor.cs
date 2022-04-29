using UnityEngine;

namespace Asteroids
{
    public class MovementMotor
    {
        private MotorStatsProvider statsProvider;

        public void SetStatsProvider(MotorStatsProvider newStatsProvider)
        {
            this.statsProvider = newStatsProvider;
        }

        public Vector2 GetNextFrameForce(Vector2 direction)
        {
            var acceleration = this.statsProvider.GetAcceleration();
            return direction.normalized * acceleration;
        }

        public Vector2 ClampToMaxSpeedVelocity(Vector2 currentVelocity)
        {
            var maxSpeed = this.statsProvider.GetMaxSpeed();
            var x = Mathf.Clamp(currentVelocity.x, -maxSpeed, maxSpeed);
            var y = Mathf.Clamp(currentVelocity.y, -maxSpeed, maxSpeed);
            return new Vector2(x, y);
        }

        public float GetNextFrameRotation(float direction, float deltaTime)
        {
            direction = Mathf.Clamp(direction, -1, 1);
            var turnSpeed = this.statsProvider.GetTurnSpeed();
            return direction * turnSpeed * deltaTime;
        }
    }
}