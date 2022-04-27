using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(menuName = "MotorStatsProvider", fileName = "MotorStatsProvider", order = 0)]
    public class MotorStatsProviderScriptableObject : ScriptableObject, MotorStatsProvider
    {
        [SerializeField] 
        private float acceleration;

        [SerializeField] 
        private float maxSpeed;
        
        [SerializeField] 
        private float turnSpeed;

        public float GetAcceleration()
        {
            return this.acceleration;
        }

        public float GetMaxSpeed()
        {
            return this.maxSpeed;
        }

        public float GetTurnSpeed()
        {
            return this.turnSpeed;
        }
    }
}