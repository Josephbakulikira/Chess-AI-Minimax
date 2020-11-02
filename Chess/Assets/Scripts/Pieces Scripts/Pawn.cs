using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override bool[,] canMove()
    {
        bool[,] bool_board = new bool[8, 8];
        Piece capture1, capture2, temp1, temp2;

        if (is_white)
        {
            if(current_x != 0 && current_y!= 7)
            {
                int[] temp_arr = Chess.Instance.EnPassant;
                if(temp_arr[0] == this.current_x- 1 && temp_arr[1] ==this.current_y  + 1)
                {
                    bool_board[this.current_x - 1, this.current_y + 1] = true;

                }
                capture1 = Chess.Instance.Pieces[current_x - 1, current_y + 1];
                if(capture1 != null && !capture1.is_white)
                {
                    bool_board[current_x - 1, current_y + 1] = true;
                }
            }
            if (current_x != 7 && current_y != 7)
            {
                int[] temp_arr = Chess.Instance.EnPassant;
                if (temp_arr[0] == this.current_x + 1 && temp_arr[1] == this.current_y + 1)
                {
                    bool_board[this.current_x +1, this.current_y + 1] = true;

                }
                capture2 = Chess.Instance.Pieces[current_x + 1, current_y + 1];
                if (capture2 != null && !capture2.is_white)
                {
                    bool_board[current_x + 1, current_y + 1] = true;
                }
            }
            if(current_y != 7)
            {

                temp1 = Chess.Instance.Pieces[current_x, current_y + 1];
                if(temp1 == null)
                {
                    bool_board[current_x, current_y + 1] = true;
                }
                
            }
            if (current_y == 1)
            {
                temp1 = Chess.Instance.Pieces[current_x, current_y + 1];
                temp2 = Chess.Instance.Pieces[current_x, current_y + 2];
                if(temp1 == null && temp2 == null)
                {
                    bool_board[current_x, current_y + 2] = true;
                    

                }
            }
        }
        else
        {

            if (current_x != 0 && current_y != 0)
            {
                int[] temp_arr = Chess.Instance.EnPassant;
                if (temp_arr[0] == this.current_x - 1 && temp_arr[1] == this.current_y - 1)
                {
                    bool_board[this.current_x - 1, this.current_y - 1] = true;

                }
                capture1 = Chess.Instance.Pieces[current_x - 1, current_y - 1];
                if (capture1 != null && capture1.is_white)
                {
                    bool_board[current_x - 1, current_y - 1] = true;
                }
            }
            if (current_x != 7 && current_y != 0)
            {
                int[] temp_arr = Chess.Instance.EnPassant;
                if (temp_arr[0] == this.current_x + 1 && temp_arr[1] == this.current_y - 1)
                {
                    bool_board[this.current_x + 1, this.current_y - 1] = true;

                }
                capture2 = Chess.Instance.Pieces[current_x + 1, current_y - 1];
                if (capture2 != null && capture2.is_white)
                {
                    bool_board[current_x + 1, current_y - 1] = true;
                }
            }
            if (current_y != 0)
            {
                temp1 = Chess.Instance.Pieces[current_x, current_y - 1];
                if (temp1 == null)
                {
                    bool_board[current_x, current_y - 1] = true;
                }

            }
            if (current_y == 6)
            {
                temp1 = Chess.Instance.Pieces[current_x, current_y - 1];
                temp2 = Chess.Instance.Pieces[current_x, current_y - 2];
                if (temp1 == null && temp2 == null)
                {
                    bool_board[current_x, current_y - 2] = true;
                }
            }
        }

        return bool_board;
    }
}
