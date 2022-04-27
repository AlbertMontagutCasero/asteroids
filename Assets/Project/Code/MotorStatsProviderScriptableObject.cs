using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(menuName = "create/MotorStatsProvider", fileName = "MotorStatsProvider", order = 0)]
    public class MotorStatsProviderScriptableObject : ScriptableObject, MotorStatsProvider
    {
        [SerializeField] 
        private float acceleration;

        [SerializeField] 
        private float maxSpeed;

        public float GetAcceleration()
        {
            return this.acceleration;
        }

        public float GetMaxSpeed()
        {
            return this.maxSpeed;
        }
    }
}