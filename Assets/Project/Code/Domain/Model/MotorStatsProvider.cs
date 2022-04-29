namespace Asteroids
{
    public interface MotorStatsProvider
    {
        float GetAcceleration();
        float GetMaxSpeed();
        float GetTurnSpeed();
    }
}