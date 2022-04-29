namespace Asteroids
{
    public interface SignalDispatcher
    {
        void Subscribe<T>(SignalDelegate callback) where T : Signal;
        void Unsubscribe<T>(SignalDelegate callback) where T : Signal;
        void Dispatch<T>(T signal) where T : Signal;
    }
}