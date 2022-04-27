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

        [SerializeField]
        private Vector2 testDirection;

        private void Awake()
        {
            this.rb = this.GetComponent<Rigidbody2D>();
            this.motor = new MovementMotor(this.statsProvider);
        }

        private void FixedUpdate()
        {
            var nextFrameForce = this.motor.GetNextFrameForce(this.testDirection);
            this.rb.AddForce(nextFrameForce);
        }
    }
}
