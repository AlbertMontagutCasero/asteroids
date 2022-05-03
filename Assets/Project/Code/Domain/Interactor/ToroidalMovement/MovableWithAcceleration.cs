using UnityEngine;

namespace Asteroids
{
    public interface MovableWithAcceleration
    {
        MovementStatsProvider GetStatsProvider();
        Vector2 GetForwardDirection();
        void ApplyForce(Vector2 nextFrameForce);
        void ClampMaxSpeed(Vector2 velocityClamped);
        Vector2 GetCurrentVelocity();
    }

    public interface ToroidalMovable
    {
        Vector2 GetPosition();
        void SetPosition(Vector2 newPosition);
    }
}