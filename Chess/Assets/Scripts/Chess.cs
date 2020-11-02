using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    public static Chess Instance { set; get; }
    
    const int width = 8;
    const int height = 8;

    public bool white_turn = true;
    public Piece[,] Pieces { set; get; }
    private Piece selectedPiece;

    private Material prev_mat;
    public Material selected_mat;
    //private int[] en_passant;
    public int[] EnPassant { get; set; }
    [SerializeField]
    float cell_size = 1.0f;
    float cell_offset = 0.5f;

    int selectedX = -1;
    int selectedY = -1;
    public List<GameObject> chess_piecesPref;
    private List<GameObject> active_chessPiece;
    bool[,] legalmoves { set; get;}
    void Start()
    {
        Instance = this;
        SpawnAllPieces();
    }
    void Update()
    {
        DisplayBoard();
        SelectTile();
        if (Input.GetMouseButtonDown(0))
        {

            if(selectedX >= 0 && selectedY >=0)
            {
                if(selectedPiece == null)
                {
                    SelectPiece(selectedX, selectedY);
                }
                else
                {
                    MovePiece(selectedX, selectedY);
                }

            }
        }
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
    void SpawnPiece(int index, int x, int y , string pieceName)
    {
        GameObject _piece = (GameObject)Instantiate(chess_piecesPref[index], GetTileCenter(x,y), Quaternion.identity);
        _piece.transform.SetParent(transform);
        _piece.name = pieceName;
        Pieces[x, y] = _piece.GetComponent<Piece>();
        Pieces[x, y].SetPosition(x, y);
        if(Pieces[x, y].current_y <= 1)
        {
            Pieces[x, y].is_white = true;
        }
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
    void SelectPiece(int x, int y)
    {
        bool hasMove = false;

        if(Pieces[x, y] == null)
        {
            return;
        }
        if(Pieces[x, y].is_white != white_turn)
        {
            
            return;
        }
        legalmoves = Pieces[x, y].canMove();
        for (int i = 0; i < width; i++)
        {
            for (int t = 0; t < height; t++)
            {
                if(legalmoves[i, t] ){
                    hasMove = true;
                }
            }
        }
        selectedPiece = Pieces[x, y];
        prev_mat = selectedPiece.transform.GetChild(0).GetComponent<MeshRenderer>().material;
        selected_mat.mainTexture = prev_mat.mainTexture;
        selectedPiece.transform.GetChild(0).GetComponent<MeshRenderer>().material = selected_mat;

        Board.Instance.DisplayLegalMoves(legalmoves);
    }
    void MovePiece(int x, int y)
    {
        if(legalmoves[x, y])
        {
            Piece temp = Pieces[x, y];
            if(temp != null && temp.is_white != white_turn)
            {
                if(temp.GetType() == typeof(King))
                {
                    CheckMate();
                    return;
                }
                active_chessPiece.Remove(temp.gameObject);
                Destroy(temp.gameObject);
            }
            if(x == EnPassant[0] && y == EnPassant[1])
            {
                if(white_turn)
                {
                    temp = Pieces[x, y-1];
                }
                else
                {
                    temp = Pieces[x, y + 1];
                    
                }
                active_chessPiece.Remove(temp.gameObject);
                Destroy(temp.gameObject);
            }

            //promote
            if(selectedPiece.GetType() == typeof(Pawn))
            {
                if(y == 7)
                {
                    active_chessPiece.Remove(selectedPiece.gameObject);
                    Destroy(selectedPiece.gameObject);
                    SpawnPiece(4, x, y, "Q");
                    selectedPiece = Pieces[x, y];
                }
                else if (y == 0)
                {
                    active_chessPiece.Remove(selectedPiece.gameObject);
                    Destroy(selectedPiece.gameObject);
                    SpawnPiece(10, x, y, "Q");
                    selectedPiece = Pieces[x, y];

                }
            }

            EnPassant[0] = -1;
            EnPassant[1] = -1;
            if (selectedPiece.GetType() == typeof(Pawn))
            {
                if(selectedPiece.current_y == 1 && y == 3)
                {
                    EnPassant[0] = x;
                    EnPassant[1] = y-1;

                }else if (selectedPiece.current_y == 6 && y == 4)
                {
                    EnPassant[0] = x;
                    EnPassant[1] = y+1;

                }
            }

            Pieces[selectedPiece.current_x, selectedPiece.current_y] = null;
            selectedPiece.transform.position = GetTileCenter(x, y);
            selectedPiece.SetPosition(x, y);
            Pieces[x, y] = selectedPiece;
            white_turn = !white_turn;

        }

        selectedPiece.transform.GetChild(0).GetComponent<MeshRenderer>().material = prev_mat;
        selectedPiece = null;
        Board.Instance.HideHighlight();
    }
    void SpawnAllPieces()
    {
        Pieces = new Piece[width, height];
        active_chessPiece = new List<GameObject>();
        EnPassant = new int[2] { -1, -1};
        //white Pieces
        //king
        SpawnPiece(1, 4, 0, "K");
        //Queen
        SpawnPiece(4, 3, 0, "Q");
        //Knights
        SpawnPiece(2, 1, 0, "N");
        SpawnPiece(2, 6, 0, "N");
        //bishops
        SpawnPiece(0, 2, 0, "B");
        SpawnPiece(0, 5, 0, "B");
        //rooks
        SpawnPiece(5, 7, 0, "R");
        SpawnPiece(5, 0, 0, "R");
        //pawns
        SpawnPiece(3, 0, 1, "P");
        SpawnPiece(3, 1, 1, "P");
        SpawnPiece(3, 2, 1, "P");
        SpawnPiece(3, 3, 1, "P");
        SpawnPiece(3, 4, 1, "P");
        SpawnPiece(3, 5, 1, "P");
        SpawnPiece(3, 6, 1, "P");
        SpawnPiece(3, 7, 1, "P");
        //black pieces
        //king
        SpawnPiece(7, 4, 7, "K");
        //Queen    
        SpawnPiece(10, 3, 7, "Q");
        //Knights  
        SpawnPiece(8, 1, 7, "N");
        SpawnPiece(8, 6, 7, "N");
        //bishops  
        SpawnPiece(6, 2, 7, "B");
        SpawnPiece(6, 5, 7, "B");
        //rooks    
        SpawnPiece(11, 7, 7, "R");
        SpawnPiece(11, 0, 7, "R");
        //pawns    
        SpawnPiece(9, 0, 6, "P");
        SpawnPiece(9, 1, 6, "P");
        SpawnPiece(9, 2, 6, "P");
        SpawnPiece(9, 3, 6, "P");
        SpawnPiece(9, 4, 6, "P");
        SpawnPiece(9, 5, 6, "P");
        SpawnPiece(9, 6, 6, "P");
        SpawnPiece(9, 7, 6, "P");
    }
    void Check()
    {
        
    }
    void CheckMate()
    {
        if (white_turn)
        {
            Debug.Log("white wins");
        }
        else
        {
            Debug.Log("black win");
        }
        foreach (GameObject p in active_chessPiece)
        {
            Destroy(p);
        }
        white_turn = true;
        Board.Instance.HideHighlight();
        SpawnAllPieces();
    }
}
