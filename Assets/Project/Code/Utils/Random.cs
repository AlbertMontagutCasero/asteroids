namespace Asteroids
{
    public interface Random
    {
    
        float GetFloatBetween(float min, float max);
        int GetIntBetween(int min, int max);
        bool GetBool();
    }
}