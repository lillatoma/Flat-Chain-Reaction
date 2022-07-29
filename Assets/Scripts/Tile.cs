using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int owner = -1;
    public int orbCount = 0;
    public int maxOrbs = 4;
    public Sprite[] orbSprites;
    public SpriteRenderer orbObj;

    public Vector2Int coords;

    private Playfield playfield;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playfield = FindObjectOfType<Playfield>();
        gameManager = FindObjectOfType<GameManager>();
        UpdateOrbs();
    }

    private void OnMouseDown()
    {
        if (!gameManager.mouseOn)
            return;

        Debug.Log("" + coords.x + "|" + coords.y);
        if(orbCount == 0 || gameManager.currentPlayer == owner)
        {
            owner = gameManager.currentPlayer;
            AddOrb();
            gameManager.NextPlayer();
            playfield.CheckExplosionLoop();
        }

    }

    public void EmptyOrb()
    {
        orbCount = 0;
        UpdateOrbs();
    }

    public void AddOrb()
    {
        orbCount++;
        UpdateOrbs();
    }

    public bool IsFull()
    {
        return orbCount >= maxOrbs;
    }

    public void UpdateOrbs()
    {
        if (owner != -1)
            orbObj.color = gameManager.playerColors[owner];
        if (orbCount >= maxOrbs)
            return;
        orbObj.sprite = orbSprites[orbCount];

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
