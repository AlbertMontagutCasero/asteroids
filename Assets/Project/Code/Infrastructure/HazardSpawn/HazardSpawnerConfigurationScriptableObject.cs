using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(menuName = "EnemySpawnerConfiguration", fileName = "EnemySpawnerConfiguration", order = 0)]
    public class HazardSpawnerConfigurationScriptableObject: ScriptableObject, HazardSpawnerConfiguration
    {
        [SerializeField, Min(0.01f)]
        private float spawnTime = 1f;
        
        public float GetSpawnTime()
        {
            return this.spawnTime;
        }
    }
}