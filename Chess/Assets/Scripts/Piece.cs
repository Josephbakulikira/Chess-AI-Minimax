using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Piece : MonoBehaviour
{
    public int current_x { get; set; }
    public int current_y { get; set; }
    public bool is_white;

    public void SetPosition(int x, int y)
    {
        this.current_x = x;
        this.current_y = y;
    }
    public virtual bool[,] canMove()
    {
        return new bool[8, 8];
    }
}
