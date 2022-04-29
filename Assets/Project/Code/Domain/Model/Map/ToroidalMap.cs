using UnityEngine;

public class ToroidalMap
{
    private readonly float width;
    private readonly float height;

    public ToroidalMap(float width, float height)
    {
        this.width = width;
        this.height = height;
    }

    public float GetWidth()
    {
        return this.width;
    }
    
    public float GetHeight()
    {
        return this.height;
    }
    
    public float GetRight()
    {
        return this.width / 2;
    }

    public float GetLeft()
    {
        return -this.GetRight();
    }
    
    public float GetTop()
    {
        return this.height / 2;
    }
    
    public float GetBottom()
    {
        return -this.GetTop();
    }

    public Vector2 CalculateToroidalPosition(Vector2 positionAfterMoving)
    {
        var resultX = positionAfterMoving.x;
        var resultY = positionAfterMoving.y;

        if (resultX > this.GetRight())
        {
            resultX = this.GetLeft();
        }
        
        if (resultX < this.GetLeft())
        {
            resultX = this.GetRight();
        }
        
        if (resultY > this.GetTop())
        {
            resultY = this.GetBottom();
        }
        
        if (resultY < this.GetBottom())
        {
            resultY = this.GetTop();
        }

        return new Vector2(resultX, resultY);
    }
}