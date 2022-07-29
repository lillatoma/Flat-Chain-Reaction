using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOrb : MonoBehaviour
{
    private Playfield playfield;
    private GameManager gameManager;

    public Vector2Int start;
    public Vector2Int end;
    public int owner;

    public float aliveTime;
    private float timeLeft;

    public void Setup(Vector2Int s, Vector2Int e, int o)
    {
        Start();
        start = s;
        end = e;
        owner = o;
        timeLeft = aliveTime;

        GetComponent<SpriteRenderer>().color = gameManager.playerColors[o];

    }

    // Start is called before the first frame update
    void Start()
    {
        playfield = FindObjectOfType<Playfield>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        transform.position = (timeLeft * playfield.GetTile(start).transform.position + (aliveTime - timeLeft) * playfield.GetTile(end).transform.position) / aliveTime;
        transform.position += new Vector3(0, 0, -1);
        if(timeLeft <= 0)
        {
            playfield.GetTile(end).owner = owner;
            playfield.GetTile(end).AddOrb();
            DestroyImmediate(this.gameObject);
        }

    }
}
