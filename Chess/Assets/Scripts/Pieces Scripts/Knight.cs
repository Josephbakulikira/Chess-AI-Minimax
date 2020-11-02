using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override bool[,] canMove()
    {
        bool[,] bool_board = new bool[8, 8];

        KnightMove(this.current_x + 2, current_y + 1, ref bool_board);
        KnightMove(this.current_x + 2, current_y - 1, ref bool_board);

        KnightMove(this.current_x - 1, current_y + 2, ref bool_board);
        KnightMove(this.current_x + 1, current_y + 2, ref bool_board);

        KnightMove(this.current_x - 1, current_y - 2, ref bool_board);
        KnightMove(this.current_x + 1, current_y - 2, ref bool_board);

        KnightMove(this.current_x - 2, current_y + 1, ref bool_board);
        KnightMove(this.current_x - 2, current_y - 1, ref bool_board);
        return bool_board;
    }

    public void KnightMove(int x, int y, ref bool[,] bool_board)
    {
        Piece temp;
        if(x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            temp = Chess.Instance.Pieces[x, y];
            if(temp == null)
            {
                bool_board[x, y] = true;
            }
            else if(this.is_white != temp.is_white)
            {
                bool_board[x, y] = true;
            }
        }
    }
}
