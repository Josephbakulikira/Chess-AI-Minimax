using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public override bool[,] canMove()
    {
        bool[,] bool_board = new bool[8, 8];
        Piece temp;
        int x;
        int y;

        x = this.current_x - 1;
        y = this.current_y + 1;
        if(this.current_y  != 7)
        {
            for (int i = 0; i < 3; i++)
            {
                if(x <= 0 || x < 8)
                {
                    temp = Chess.Instance.Pieces[x, y];
                    if(temp == null)
                    {
                        bool_board[x, y] = true;
                    }
                    else if(temp.is_white != this.is_white)
                    {
                        bool_board[x, y] = true; 
                    }
                    x++;
                }
            }
        }
        x = this.current_x - 1;
        y = this.current_y - 1;
        if (this.current_y != 0)
        {
            for (int i = 0; i < 3; i++)
            {
                if (x <= 0 || x < 8)
                {
                    temp = Chess.Instance.Pieces[x, y];
                    if (temp == null)
                    {
                        bool_board[x, y] = true;
                    }
                    else if (temp.is_white != this.is_white)
                    {
                        bool_board[x, y] = true;
                    }
                    x++;
                }
            }
        }
        
        if (this.current_x != 0)
        {
            temp = Chess.Instance.Pieces[this.current_x - 1, this.current_y];
            if(temp == null)
            {
                bool_board[this.current_x - 1, this.current_y] = true;
            }else if(this.is_white != temp.is_white)
            {
                bool_board[this.current_x - 1, this.current_y] = true;

            }
        }
        if (this.current_x != 7)
        {
            temp = Chess.Instance.Pieces[this.current_x + 1, this.current_y];
            if (temp == null)
            {
                bool_board[this.current_x + 1, this.current_y] = true;
            }
            else if (this.is_white != temp.is_white)
            {
                bool_board[this.current_x + 1, this.current_y] = true;

            }
        }
        return bool_board;
    }
}
