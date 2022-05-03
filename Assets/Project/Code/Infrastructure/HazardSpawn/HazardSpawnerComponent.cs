using UnityEngine;

namespace Asteroids
{
    public class HazardSpawnerComponent: MonoBehaviour, HazardSpawner
    {
        [SerializeField]
        private HazardComponent hazardPrefab;
        
        private SpawnNewHazardUseCase useCase;

        private void Start()
        {
            this.useCase = DomainServiceLocator.GetInstance().GetService<SpawnNewHazardUseCase>();
        }

        private void Update()
        {
            this.useCase.AddTime(Time.deltaTime);
        }

        public void SpawnEnemy(HazardMovement hazardMovement)
        {
            var hazardComponent = Instantiate(this.hazardPrefab);
            hazardComponent.SetUp(hazardMovement);
        }
    }
}