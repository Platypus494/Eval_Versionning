using System;
using UnityEngine;

public struct MyVector2 
{
    private float _x;
    public float X => _x;

    private float _y;
    public float Y => _y;

    public float magnitude;
    public float sqrMagnitude;

    public MyVector2(float x, float y)
    {
        if(x < 0 || y < 0)
        {
            throw new ArgumentException();
        }
        _x =x ;
        _y = y;
        magnitude = x * x + y * y;
        sqrMagnitude = Mathf.Sqrt(magnitude);
    }

    public void Normalize()
    {
        _x=X/sqrMagnitude; 
        _y=Y/sqrMagnitude;
        magnitude = 1;
        sqrMagnitude = 1;
    }

    public static MyVector2 operator +(MyVector2 left, MyVector2 right)
    {
        return new MyVector2(left.X + right.X, left.Y + right.Y);
    }
}
