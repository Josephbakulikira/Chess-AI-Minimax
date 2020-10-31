using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    const int width = 8;
    const int height = 8;

    [SerializeField]
    float cell_size = 1.0f;
    float cell_offset = 0.5f;

    int selectedX = -1;
    int selectedY = -1;
    public List<GameObject> chess_piecesPref;
    private List<GameObject> active_chessPiece;
    void Start()
    {
        SpawnAllPieces();
    }
    void Update()
    {
        DisplayBoard();
        SelectTile();
    }
    void DisplayBoard()
    {
        Vector3 widthLine = Vector3.right * width;
        Vector3 heightLine = Vector3.forward * height;

        for (int x = 0; x <= width; x++)
        {
            Vector3 start = Vector3.forward * x;
            Debug.DrawLine(start, start + widthLine);
            for (int y = 0; y <= height; y++)
            {
                start = Vector3.right * y;
                Debug.DrawLine(start, start + heightLine);
            }
        }
        if(selectedY >= 0 && selectedX >= 0)
        {
            

            Debug.DrawLine(Vector3.forward * (selectedY+1) + Vector3.right * selectedX, Vector3.forward * selectedY + Vector3.right * (selectedX + 1), Color.blue);
            Debug.DrawLine(Vector3.forward * selectedY + Vector3.right * selectedX, Vector3.forward * (selectedY + 1) + Vector3.right * (selectedX + 1), Color.blue);
        }
    }
    void SpawnPiece(int index, Vector3 position, string pieceName)
    {
        GameObject _piece = (GameObject)Instantiate(chess_piecesPref[index], position, Quaternion.identity);
        _piece.transform.SetParent(transform);
        _piece.name = pieceName;
        active_chessPiece.Add(_piece);

    }
    void SelectTile()
    {
        if (!Camera.main)
            return;
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50.0f,LayerMask.GetMask("ChessPlane") ))
        {
            selectedX = (int)hit.point.x;
            selectedY = (int)hit.point.z;
        }
        else
        {
            selectedX = -1;
            selectedY = -1;
        }
    }
    Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (cell_size * x) + cell_offset;
        origin.z += (cell_size * y) + cell_offset;
        return origin;
    }
    void SpawnAllPieces()
    {
        active_chessPiece = new List<GameObject>();
        //white Pieces
        //king
        SpawnPiece(1, GetTileCenter(4, 0), "K");
        //Queen
        SpawnPiece(1, GetTileCenter(3, 0), "Q");
        //Knights
        SpawnPiece(1, GetTileCenter(1, 0), "N");
        SpawnPiece(1, GetTileCenter(6, 0), "N");
        //bishops
        SpawnPiece(1, GetTileCenter(2, 0), "B");
        SpawnPiece(1, GetTileCenter(5, 0), "B");
        //rooks
        SpawnPiece(1, GetTileCenter(7, 0), "R");
        SpawnPiece(1, GetTileCenter(0, 0), "R");
        //pawns
        SpawnPiece(1, GetTileCenter(0, 1), "P");
        SpawnPiece(1, GetTileCenter(1, 1), "P");
        SpawnPiece(1, GetTileCenter(2, 1), "P");
        SpawnPiece(1, GetTileCenter(3, 1), "P");
        SpawnPiece(1, GetTileCenter(4, 1), "P");
        SpawnPiece(1, GetTileCenter(5, 1), "P");
        SpawnPiece(1, GetTileCenter(6, 1), "P");
        SpawnPiece(1, GetTileCenter(7, 1), "P");
        //black pieces
        //king
        SpawnPiece(0, GetTileCenter(4, 7), "K");
        //Queen    
        SpawnPiece(0, GetTileCenter(3, 7), "Q");
        //Knights  
        SpawnPiece(0, GetTileCenter(1, 7), "N");
        SpawnPiece(0, GetTileCenter(6, 7), "N");
        //bishops  
        SpawnPiece(0, GetTileCenter(2, 7), "B");
        SpawnPiece(0, GetTileCenter(5, 7), "B");
        //rooks    
        SpawnPiece(0, GetTileCenter(7, 7), "R");
        SpawnPiece(0, GetTileCenter(0, 7), "R");
        //pawns    
        SpawnPiece(0, GetTileCenter(0, 6), "P");
        SpawnPiece(0, GetTileCenter(1, 6), "P");
        SpawnPiece(0, GetTileCenter(2, 6), "P");
        SpawnPiece(0, GetTileCenter(3, 6), "P");
        SpawnPiece(0, GetTileCenter(4, 6), "P");
        SpawnPiece(0, GetTileCenter(5, 6), "P");
        SpawnPiece(0, GetTileCenter(6, 6), "P");
        SpawnPiece(0, GetTileCenter(7, 6), "P");
    }
}
