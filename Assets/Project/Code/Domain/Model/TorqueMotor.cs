using UnityEngine;

namespace Asteroids
{
    public class TorqueMotor
    {
        private MovementStatsProvider statsProvider;

        public void SetStatsProvider(MovementStatsProvider newStatsProvider)
        {
            this.statsProvider = newStatsProvider;
        }
        
        public float GetNextFrameRotation(float direction, float deltaTime)
        {
            direction = Mathf.Clamp(direction, -1, 1);
            var turnSpeed = this.statsProvider.GetTurnSpeed();
            return direction * turnSpeed * deltaTime;
        }
    }
}