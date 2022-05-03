using UnityEngine;

namespace Asteroids
{
    public class HazardSpawnerComponent: MonoBehaviour, HazardSpawner
    {
        [SerializeField]
        private GameObject hazardPrefab;
        
        private SpawnNewHazardUseCase useCase;

        private void Start()
        {
            this.useCase = DomainServiceLocator.GetInstance().GetService<SpawnNewHazardUseCase>();
        }

        private void Update()
        {
            this.useCase.AddTime(Time.deltaTime);
        }

        public void SpawnEnemy()
        {
            Instantiate(this.hazardPrefab);
        }
    }
}