using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids
{
    public class InputController : MonoBehaviour
    {
        private AccelerationMovementComponent accelerationMovementComponent;

        public void MoveRequest(InputAction.CallbackContext context)
        {
            var isStartMovingRequest = context.started || context.performed;
            var isStopMovingRequest = context.canceled;

            if (isStartMovingRequest)
            {
                this.accelerationMovementComponent.RequestMove();
            }
            
            if (isStopMovingRequest)
            {
                this.accelerationMovementComponent.RequestStopMovement();
            }
        } 
    
        public void TurnRequest(InputAction.CallbackContext context)
        {
            var isStartRotatingRequest = context.started || context.performed;
            var isStopRotatingRequest = context.canceled;

            if (isStartRotatingRequest)
            {
                var readValue = context.ReadValue<float>();
                this.accelerationMovementComponent.RequestTurn(readValue);
            }
            
            if (isStopRotatingRequest)
            {
                this.accelerationMovementComponent.RequestTurn(0);
            }
        }

        public void SetMovementComponent(AccelerationMovementComponent newAccelerationMovementComponent)
        {
            this.accelerationMovementComponent = newAccelerationMovementComponent;
        }
    }
}