using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override bool[,] canMove()
    {
        bool[,] bool_board = new bool[8, 8];

        Piece temp;

        int x, y, index;
        index = this.current_x;
        while (true)
        {
            index++;
            if (index >= 8)
            {
                break;
            }
            temp = Chess.Instance.Pieces[index, current_y];
            if (temp == null)
            {
                bool_board[index, current_y] = true;
            }
            else
            {
                if (temp.is_white != this.is_white)
                {
                    bool_board[index, current_y] = true;
                }
                break;
            }
        }
        index = this.current_x;
        while (true)
        {
            index--;
            if (index < 0)
            {
                break;
            }
            temp = Chess.Instance.Pieces[index, current_y];
            if (temp == null)
            {
                bool_board[index, current_y] = true;
            }
            else
            {
                if (temp.is_white != this.is_white)
                {
                    bool_board[index, current_y] = true;
                }
                break;
            }
        }
        index = this.current_y;
        while (true)
        {
            index++;
            if (index >= 8)
            {
                break;
            }
            temp = Chess.Instance.Pieces[this.current_x, index];
            if (temp == null)
            {
                bool_board[this.current_x, index] = true;
            }
            else
            {
                if (temp.is_white != this.is_white)
                {
                    bool_board[this.current_x, index] = true;
                }
                break;
            }
        }
        index = this.current_y;
        while (true)
        {
            index--;
            if (index < 0)
            {
                break;
            }
            temp = Chess.Instance.Pieces[this.current_x, index];
            if (temp == null)
            {
                bool_board[this.current_x, index] = true;
            }
            else
            {
                if (temp.is_white != this.is_white)
                {
                    bool_board[this.current_x, index] = true;
                }
                break;
            }
        }


        x = this.current_x;
        y = this.current_y;
        while (true)
        {
            x--;
            y++;
            if (x < 0 || y >= 8)
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
            if (x < 0 || y < 0)
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