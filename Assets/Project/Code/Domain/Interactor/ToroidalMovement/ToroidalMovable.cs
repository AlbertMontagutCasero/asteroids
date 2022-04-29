using UnityEngine;

namespace Asteroids
{
    public interface ToroidalMovable
    {
        MotorStatsProvider GetStatsProvider();
        Vector2 GetForwardDirection();
        void ApplyForce(Vector2 nextFrameForce);
        void ClampMaxSpeed(Vector2 velocityClamped);
        Vector2 GetPosition();
        Vector2 GetCurrentVelocity();
        void SetPosition(Vector2 newPosition);
    }
}