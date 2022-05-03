namespace Asteroids
{
    public class RandomUnity: Random
    {
        public float GetFloatBetween(float minInclusive, float maxInclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxInclusive);
        }

        public int GetIntBetween(int minInclusive, int maxExclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxExclusive);
        }

        public bool GetBool()
        {
            return UnityEngine.Random.Range(0, 1) == 1;
        }
    }
}