using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int owner = -1;
    public int orbCount = 0;
    public Sprite[] orbSprites;
    public SpriteRenderer orbObj;

    public Vector2Int coords;

    private Playfield playfield;


    // Start is called before the first frame update
    void Start()
    {
        playfield = FindObjectOfType<Playfield>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
