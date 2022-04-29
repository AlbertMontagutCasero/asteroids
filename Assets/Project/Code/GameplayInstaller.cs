using UnityEngine;

namespace Asteroids
{
    public class GameplayInstaller: MonoBehaviour
    {
        [SerializeField]
        private InputController inputControllerPrefab;
        
        [SerializeField]
        private MovementComponent playerPrefab;

        [SerializeField] 
        private AsteroidsCamera asteroidsCameraPrefab;

        private InputController inputController;
        private MovementComponent player;

        private void Start()
        {
            this.player = Instantiate(this.playerPrefab);
            var asteroidsCamera = Instantiate(this.asteroidsCameraPrefab);
            var mapSizeProvider = new ToroidalMapProvider(asteroidsCamera);
            var map = mapSizeProvider.GetMap();
            
            var domainEventDispatcher = new DomainSignalDispatcher();
            
            var toroidalMovementUseCase = new ToroidalMovementUseCase(map, domainEventDispatcher);
            var turnUseCase = new TurnUseCase();
            
            DomainServiceLocator.GetInstance().RegisterController(toroidalMovementUseCase);
            DomainServiceLocator.GetInstance().RegisterController(turnUseCase);

            this.inputController = Instantiate(this.inputControllerPrefab);
            this.inputController.SetMovementComponent(this.player);
        }
    }
}



