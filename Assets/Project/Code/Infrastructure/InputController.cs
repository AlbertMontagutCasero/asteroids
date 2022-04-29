using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids
{
    public class InputController : MonoBehaviour
    {
        private MovementComponent movementComponent;

        public void MoveRequest(InputAction.CallbackContext context)
        {
            var isStartMovingRequest = context.started || context.performed;
            var isStopMovingRequest = context.canceled;

            if (isStartMovingRequest)
            {
                this.movementComponent.RequestMove();
            }
            
            if (isStopMovingRequest)
            {
                this.movementComponent.RequestStopMovement();
            }
        } 
    
        public void TurnRequest(InputAction.CallbackContext context)
        {
            var isStartRotatingRequest = context.started || context.performed;
            var isStopRotatingRequest = context.canceled;

            if (isStartRotatingRequest)
            {
                var readValue = context.ReadValue<float>();
                this.movementComponent.RequestTurn(readValue);
            }
            
            if (isStopRotatingRequest)
            {
                this.movementComponent.RequestTurn(0);
            }
        }

        public void SetMovementComponent(MovementComponent newMovementComponent)
        {
            this.movementComponent = newMovementComponent;
        }
    }
}