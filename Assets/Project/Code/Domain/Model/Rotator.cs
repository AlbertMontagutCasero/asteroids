namespace Asteroids
{
    public interface Rotator
    {
        void Rotate(float zAngle);
        MotorStatsProvider GetStatsProvider();
    }
}