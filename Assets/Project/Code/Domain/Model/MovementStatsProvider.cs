namespace Asteroids
{
    public interface MovementStatsProvider
    {
        float GetAcceleration();
        float GetMaxSpeed();
        float GetTurnSpeed();
    }
}