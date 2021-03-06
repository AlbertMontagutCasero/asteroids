using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(menuName = "MotorStatsProvider", fileName = "MotorStatsProvider", order = 0)]
    public class MovementStatsProviderScriptableObject : ScriptableObject, MovementStatsProvider
    {
        [SerializeField] 
        private float acceleration;

        [SerializeField] 
        private float maxSpeed;
        
        [SerializeField] 
        private float turnSpeed;
        
        [SerializeField] 
        private float drag = 0.5f;

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
        
        public float GetDrag()
        {
            return this.drag;
        }
    }
}