using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Choice
{
    WHITE, BLACK
};

public class Piece 
{
    int x;
    int y;
    Choice color = Choice.WHITE;

    public Piece(int x, int y, Choice color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }
    public int GetX()
    {
        return this.x;
    }
    public int GetY()
    {
        return this.y;
    }
    public void SetX(int _x)
    {
        this.x = _x;
    }
    public void SetY(int _y)
    {
        this.y = _y;
    }
    public Choice GetColor()
    {
        return this.color;
    }
    public void SetColor(Choice _color)
    {
        this.color = _color;
    }
}
