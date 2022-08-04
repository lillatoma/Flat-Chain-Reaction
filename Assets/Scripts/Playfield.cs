using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    public GameObject tilePrefab;
    public Tile[] tileList;
    public Vector2Int mapSize;

    public GameObject movingOrbPrefab;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        tileList = new Tile[mapSize.x * mapSize.y];

        for (int y = 0; y < mapSize.y; y++)
            for (int x = 0; x < mapSize.x; x++)
            {
                GameObject go = Instantiate(tilePrefab,this.transform);
                go.transform.position = new Vector3(1f * x - 0.5f * mapSize.x + 0.5f, 1f * y - 0.5f * mapSize.y + 0.5f, 0);
                tileList[y * mapSize.x + x] = go.GetComponent<Tile>();
                go.GetComponent<Tile>().coords = new Vector2Int(x, y);
                if (x == 0 || x == mapSize.x - 1)
                    go.GetComponent<Tile>().maxOrbs--;
                if (y == 0 || y == mapSize.y - 1)
                    go.GetComponent<Tile>().maxOrbs--;
            }
    }

    public void RestartGame()
    {
        for(int i = 0; i < tileList.Length; i++)
        {
            tileList[i].orbCount = 0;
            tileList[i].owner = -1;
            tileList[i].UpdateOrbs();
        }
        gameManager.SetGameUpForBeginning();
    }

    bool IsValidCoord(int x, int y)
    {
        if (x < 0 || x >= mapSize.x || y < 0 || y >= mapSize.y)
            return false;
        return true;
    }
    public Tile GetTile(int x, int y)
    {
        return tileList[y * mapSize.x + x];
    }

    public Tile GetTile(Vector2Int v)
    {
        return tileList[v.y * mapSize.x + v.x];
    }

    void QuickOrbExplosion(int x, int y)
    {
        int color = GetTile(x, y).owner;
        GetTile(x, y).EmptyOrb();

        if (IsValidCoord(x - 1, y))
        {
            GameObject go = Instantiate(movingOrbPrefab);
            MovingOrb orb = go.GetComponent<MovingOrb>();
            orb.Setup(new Vector2Int(x, y), new Vector2Int(x - 1, y), color);
        }

        if (IsValidCoord(x + 1, y))
        {
            GameObject go = Instantiate(movingOrbPrefab);
            MovingOrb orb = go.GetComponent<MovingOrb>();
            orb.Setup(new Vector2Int(x, y), new Vector2Int(x + 1, y), color);
        }
        if (IsValidCoord(x, y - 1))
        {
            GameObject go = Instantiate(movingOrbPrefab);
            MovingOrb orb = go.GetComponent<MovingOrb>();
            orb.Setup(new Vector2Int(x, y), new Vector2Int(x, y - 1), color);
        }
        if (IsValidCoord(x, y + 1))
        {
            GameObject go = Instantiate(movingOrbPrefab);
            MovingOrb orb = go.GetComponent<MovingOrb>();
            orb.Setup(new Vector2Int(x, y), new Vector2Int(x, y + 1), color);
        }
    }

    public void CheckForDeadPlayers()
    {
        for (int i = 0; i < 8; i++)
            gameManager.playerAlive[i] = false;

        for (int x = 0; x < mapSize.x; x++)
            for (int y = 0; y < mapSize.y; y++)
                if (GetTile(x, y).orbCount > 0 && GetTile(x,y).owner >= 0)
                    gameManager.playerAlive[GetTile(x, y).owner] = true;

    }

    public void CheckExplosionLoop()
    {
        StartCoroutine(ExplosionLoop());
    }

    IEnumerator ExplosionLoop()
    {
        gameManager.LockMouse();
        while (CheckForOrbExplosions())
        {
            yield return new WaitForSeconds(0.35f);
            CheckForDeadPlayers();
        }
        gameManager.UnlockMouse();
    }

    public bool CheckForOrbExplosions()
    {
        List<Vector2Int> exp = new List<Vector2Int>();

        bool found = false;

        for(int y = 0; y < mapSize.y; y++)
            for(int x = 0; x < mapSize.x; x++)
            {
                if (GetTile(x, y).IsFull())
                {
                    found = true;
                    exp.Add(new Vector2Int(x, y));
                }
                        //QuickOrbExplosion(x, y);
            }

        for (int i = 0; i < exp.Count; i++)
            QuickOrbExplosion(exp[i].x, exp[i].y);
        return found;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
