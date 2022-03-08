using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject TilePrefab;
    public Material lightGrass;
    public Material darkGrass;
    
    public ArrayList Tiles = new ArrayList();
    private Vector3 cubeOffset = new Vector3(0.5f, -0.5f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Vector3 p = new Vector3(i, 0, j) + cubeOffset;
                GameObject tile = (GameObject)Instantiate(TilePrefab, p, Quaternion.identity);
                Renderer renderer = tile.GetComponent<MeshRenderer>();

                if (j % 2 == i % 2)
                {
                    tile.transform.Translate(0, 0.00f, 0);
                    renderer.material = lightGrass;
                }
                else
                {
                    renderer.material = darkGrass;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
