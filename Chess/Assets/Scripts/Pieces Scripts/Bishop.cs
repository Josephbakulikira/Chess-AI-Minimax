using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override bool[,] canMove()
    {
        bool[,] bool_board = new bool[8, 8];
        Piece temp;
        int x;
        int y;
        x = this.current_x;
        y = this.current_y;
        while (true)
        {
            x--;
            y++;
            if(x < 0 || y >= 8)
            {
                break;
            }
            temp = Chess.Instance.Pieces[x, y];
            if(temp == null)
            {
                bool_board[x, y] = true;
            }
            else
            {
                if(temp.is_white != this.is_white)
                {
                    bool_board[x, y] = true;
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        x = this.current_x;
        y = this.current_y;
        while (true)
        {
            x++;
            y++;
            if (x >= 8 || y >= 8)
            {
                break;
            }
            temp = Chess.Instance.Pieces[x, y];
            if (temp == null)
            {
                bool_board[x, y] = true;
            }
            else
            {
                if (temp.is_white != this.is_white)
                {
                    bool_board[x, y] = true;
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        x = this.current_x;
        y = this.current_y;
        while (true)
        {
            x--;
            y--;
            if (x < 0|| y < 0)
            {
                break;
            }
            temp = Chess.Instance.Pieces[x, y];
            if (temp == null)
            {
                bool_board[x, y] = true;
            }
            else
            {
                if (temp.is_white != this.is_white)
                {
                    bool_board[x, y] = true;
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        x = this.current_x;
        y = this.current_y;
        while (true)
        {
            x++;
            y--;
            if (x >= 8 || y < 0)
            {
                break;
            }
            temp = Chess.Instance.Pieces[x, y];
            if (temp == null)
            {
                bool_board[x, y] = true;
            }
            else
            {
                if (temp.is_white != this.is_white)
                {
                    bool_board[x, y] = true;
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        return bool_board;
    }
}