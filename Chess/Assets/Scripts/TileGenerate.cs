using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerate : MonoBehaviour
{
    public GameObject pref;
    public List<Material> materials;
    
    void Start()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject obj = Instantiate(pref, new Vector3(x+0.5f, -0.25f, y+0.5f), transform.rotation);
                if (y%2 != 0)
                {
                    if (x % 2 == 0)
                        obj.GetComponent<MeshRenderer>().material = materials[1];
                    else 
                        obj.GetComponent<MeshRenderer>().material = materials[0];

                }
                else
                {
                    if (x % 2 == 0)
                        obj.GetComponent<MeshRenderer>().material = materials[0];
                    else
                        obj.GetComponent<MeshRenderer>().material = materials[1];
                }
                obj.transform.SetParent(this.transform);
            }
        }
    }


}
