using UnityEngine;

namespace Asteroids
{
    public class MovablePositionUpdatedSignal : Signal
    {
        public Vector3 Position { get; internal set; }
    }
}