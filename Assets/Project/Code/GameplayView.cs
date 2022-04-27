using UnityEngine;

namespace Asteroids
{
    public class GameplayView: MonoBehaviour
    {
        [SerializeField]
        private InputController inputControllerPrefab;
        
        [SerializeField]
        private MovementComponent playerPrefab;

        private InputController inputController;
        private MovementComponent player;

        private void Start()
        {
            this.inputController = Instantiate(this.inputControllerPrefab);
            this.player = Instantiate(this.playerPrefab);

            this.inputController.SetMovementComponent(this.player);
        }
    }
}