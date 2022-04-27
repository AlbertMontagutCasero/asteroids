using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] 
        private MotorStatsProviderScriptableObject statsProvider;
        
        private Rigidbody2D rb;
        private MovementMotor motor;

        private float turnDirection;
        private bool moveRequested;

        private void Awake()
        {
            this.rb = this.GetComponent<Rigidbody2D>();
            this.motor = new MovementMotor(this.statsProvider);
        }

        public void RequestTurn(float requestedDirection)
        {
            this.turnDirection = requestedDirection;
        }
        
        public void RequestMove()
        {
            this.moveRequested = true;
        }
        
        public void RequestStopMovement()
        {
            this.moveRequested = false;
        }
        
        private void FixedUpdate()
        {
            if (!this.moveRequested)
            {
                return;
            }
            
            var nextFrameForce = this.motor.GetNextFrameForce(this.transform.up);
            this.rb.AddForce(nextFrameForce);

            this.rb.velocity = this.motor.ClampToMaxSpeedVelocity(this.rb.velocity);
        }

        private void Update()
        {
            var zRotation = this.motor.GetNextFrameRotation(this.turnDirection, Time.deltaTime);
            this.transform.Rotate(0,0, zRotation);
        }
    }
}
