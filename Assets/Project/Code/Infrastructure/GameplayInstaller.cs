using UnityEngine;

namespace Asteroids
{
    public class GameplayInstaller: MonoBehaviour
    {
        [SerializeField]
        private InputController inputControllerPrefab;
        
        [SerializeField]
        private AccelerationMovementComponent playerPrefab;

        [SerializeField] 
        private AsteroidsCamera asteroidsCameraPrefab;
        
        [SerializeField] 
        private HazardSpawnerConfigurationScriptableObject hazardSpawnerConfiguration;
        [SerializeField] 
        private HazardSpawnerComponent hazardSpawnerPrefab;

        private InputController inputController;
        private AccelerationMovementComponent player;

        private void Start()
        {
            this.player = Instantiate(this.playerPrefab);
            var asteroidsCamera = Instantiate(this.asteroidsCameraPrefab);
            var mapSizeProvider = new ToroidalMapProvider(asteroidsCamera);
            var map = mapSizeProvider.GetMap();
            
            var accelerationMovementUseCase = new AccelerationMovementUseCase();
            var toroidalMovementUseCase = new ToroidalMovementUseCase(map);
            var turnUseCase = new TurnUseCase();
            var enemySpawner = Instantiate(this.hazardSpawnerPrefab);
            var spawnEnemyUseCase = new SpawnNewHazardUseCase(this.hazardSpawnerConfiguration, enemySpawner);
            
            DomainServiceLocator.GetInstance().RegisterController(toroidalMovementUseCase);
            DomainServiceLocator.GetInstance().RegisterController(turnUseCase);
            DomainServiceLocator.GetInstance().RegisterController(spawnEnemyUseCase);
            DomainServiceLocator.GetInstance().RegisterController(accelerationMovementUseCase);

            this.inputController = Instantiate(this.inputControllerPrefab);
            this.inputController.SetMovementComponent(this.player);
        }
    }
}



