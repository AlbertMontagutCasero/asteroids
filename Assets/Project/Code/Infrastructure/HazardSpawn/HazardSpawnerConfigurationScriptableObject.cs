using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(menuName = "EnemySpawnerConfiguration", fileName = "EnemySpawnerConfiguration", order = 0)]
    public class HazardSpawnerConfigurationScriptableObject: ScriptableObject, HazardSpawnerConfiguration
    {
        [SerializeField, Min(0.01f)]
        private float spawnTime = 1f;
        
        [SerializeField]
        private float minSpeed = 1f;

        [SerializeField]
        private float maxSpeed = 1f;

        public float GetSpawnTime()
        {
            return this.spawnTime;
        }

        public float GetMinSpeed()
        {
            return this.minSpeed;
        }

        public float GetMaxSpeed()
        {
            return this.maxSpeed;
        }
    }
}