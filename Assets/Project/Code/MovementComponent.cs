using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour, ToroidalMovable
    {
        [SerializeField] 
        private MotorStatsProviderScriptableObject statsProvider;
        
        private Rigidbody2D rb;
        private MovementMotor motor;

        private float turnDirection;
        private bool moveRequested;
        private ToroidalMovementUseCase toroidalMovementUseCase;

        private void Awake()
        {
            this.rb = this.GetComponent<Rigidbody2D>();
            
            // SRP VIOLATION: Motor tiene 2 responsabilidad mover y rotar, dos motivos de cambio, hay objetos que no
            // hace falta que roten cada frame
            this.motor = new MovementMotor();
            this.motor.SetStatsProvider(this.statsProvider);
        }

        private void Start()
        {
            this.toroidalMovementUseCase = DomainServiceLocator.GetInstance().GetService<ToroidalMovementUseCase>();
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
            if (this.moveRequested)
            {
                this.toroidalMovementUseCase.Move(this);
                return;
            }
            
            this.toroidalMovementUseCase.ExecuteMovementByInertia(this);
        }

        private void Update()
        {
            var zRotation = this.motor.GetNextFrameRotation(this.turnDirection, Time.deltaTime);
            this.transform.Rotate(0,0, zRotation);
        }

        public MotorStatsProvider GetStatsProvider()
        {
            return this.statsProvider;
        }

        public Vector2 GetForwardDirection()
        {
            return this.transform.up;
        }
        
        public void ApplyForce(Vector2 nextFrameForce)
        {
            this.rb.AddForce(nextFrameForce);
        }

        public void ClampMaxSpeed(Vector2 velocityClamped)
        {
            this.rb.velocity = velocityClamped;
        }

        public Vector2 GetPosition()
        {
            return this.rb.position;
        }

        public Vector2 GetCurrentVelocity()
        {
            return this.rb.velocity;
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.rb.position = newPosition;
        }
    }
}
