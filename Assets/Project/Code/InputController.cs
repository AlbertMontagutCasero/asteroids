using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids
{
    public class InputController : MonoBehaviour
    {
        public void MoveRequest(InputAction.CallbackContext context)
        {
            Debug.Log("Move");
            Debug.Log(context);
        } 
    
        public void TurnRequest(InputAction.CallbackContext context)
        {
            Debug.Log("Turn");
            Debug.Log(context);
        } 
    }
}