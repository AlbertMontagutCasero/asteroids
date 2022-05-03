using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AccelerationMovementComponent : MonoBehaviour, MovableWithAcceleration, Rotator, ToroidalMovable
    {
        [SerializeField] 
        private MovementStatsProviderScriptableObject statsProvider;
        
        private Rigidbody2D rb;

        private float turnDirection;
        private bool moveRequested;
        
        private ToroidalMovementUseCase toroidalMovementUseCase;
        private AccelerationMovementUseCase accelerationMovementUseCase;
        private TurnUseCase turnUseCase;

        private void Awake()
        {
            this.rb = this.GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            this.toroidalMovementUseCase = DomainServiceLocator.GetInstance().GetService<ToroidalMovementUseCase>();
            this.turnUseCase = DomainServiceLocator.GetInstance().GetService<TurnUseCase>();
            this.accelerationMovementUseCase = DomainServiceLocator.GetInstance().GetService<AccelerationMovementUseCase>();
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
                this.accelerationMovementUseCase.Move(this);
            }
            
            this.toroidalMovementUseCase.ExecuteMovementByInertia(this);
        }

        private void Update()
        {
            this.turnUseCase.Turn(this, this.turnDirection, Time.deltaTime);
        }

        public MovementStatsProvider GetStatsProvider()
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

        public void Rotate(float zAngle)
        {
            this.transform.Rotate(0,0, zAngle);
        }
    }
}
