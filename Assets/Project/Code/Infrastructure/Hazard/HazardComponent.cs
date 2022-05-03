using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HazardComponent: MonoBehaviour, ToroidalMovable
    {
        private HazardMovement hazardMovement;
        private ToroidalMovementUseCase useCase;
        private Rigidbody2D rb;

        private void Awake()
        {
            this.rb = this.GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            this.useCase = DomainServiceLocator.GetInstance().GetService<ToroidalMovementUseCase>();
        }

        public void SetUp(HazardMovement newHazardMovement)
        {
            this.transform.Rotate(new Vector3(0,0, newHazardMovement.GetAngle()));
            this.rb.velocity = this.transform.up * newHazardMovement.GetSpeed();
        }

        private void Update()
        {
            this.useCase.ExecuteMovementByInertia(this);
        }

        public Vector2 GetPosition()
        {
            return this.rb.position;
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.rb.position = newPosition;
        }
    }
}