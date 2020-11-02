using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board :MonoBehaviour
{
    const int width = 8;
    const int height = 8;
    public static Board Instance { set; get;}
    public GameObject HighlightPref;
    private List<GameObject> highlight;

    void Start()
    {
        Instance = this;
        highlight = new List<GameObject>();
    }
    GameObject getHighlight()
    {
        GameObject tile = highlight.Find(g => !g.activeSelf);
        if(tile == null)
        {
            tile = Instantiate(HighlightPref);
            highlight.Add(tile);
        }
        return tile;
    }
    public void DisplayLegalMoves(bool[,] moves)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(moves[x, y])
                {
                    GameObject tile = getHighlight();
                    tile.SetActive(true);
                    tile.transform.position = new Vector3(x+0.5f, 0, y+0.5f);
                }
            }
        }
    }
    public void HideHighlight()
    {
        foreach(GameObject tile in highlight)
        {
            tile.SetActive(false);
        }
    }
}
