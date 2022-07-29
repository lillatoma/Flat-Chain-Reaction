using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    public GameObject tilePrefab;
    public Tile[] tileList;
    public Vector2Int mapSize;

    // Start is called before the first frame update
    void Start()
    {
        tileList = new Tile[mapSize.x * mapSize.y];

        for (int y = 0; y < mapSize.y; y++)
            for (int x = 0; x < mapSize.x; x++)
            {
                GameObject go = Instantiate(tilePrefab,this.transform);
                go.transform.position = new Vector3(1f * x - 0.5f * mapSize.x + 0.5f, 1f * y - 0.5f * mapSize.y + 0.5f, 0);
                go.GetComponent<Tile>().coords = new Vector2Int(x, y);

            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
