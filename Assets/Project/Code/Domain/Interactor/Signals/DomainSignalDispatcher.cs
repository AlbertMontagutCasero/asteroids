using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class DomainSignalDispatcher : SignalDispatcher
    {
        private readonly Dictionary<Type, SignalDelegate> signals;

        public DomainSignalDispatcher()
        {
            this.signals = new Dictionary<Type, SignalDelegate>();
        }

        public void Subscribe<T>(SignalDelegate callback) where T : Signal
        {
            var type = typeof(T);
            if (!this.signals.ContainsKey(type))
            {
                this.signals.Add(type, null);
            }

            this.signals[type] += callback;
        }

        public void Unsubscribe<T>(SignalDelegate callback) where T : Signal
        {
            var type = typeof(T);
            if (this.signals.ContainsKey(type))
            {
                this.signals[type] -= callback;
            }
        }

        public void Dispatch<T>(T signal) where T : Signal
        {
            var type = typeof(T);
            if (!this.signals.ContainsKey(type))
                return;
            this.signals[type](signal);
        }
    }
}