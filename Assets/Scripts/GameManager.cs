using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentPlayer;
    public int maxPlayers;
    public string[] playerNames;
    public Color[] playerColors;
    public bool[] playerAlive;

    public bool mouseOn = true;

    public int GetWinner()
    {
        if (!IsOver())
            return -1;
        else
            for (int i = 0; i < maxPlayers; i++)
                if (playerAlive[i])
                    return i;
        return -1;
    }
    public bool IsOver()
    {
        int playerCount = 0;
        for (int i = 0; i < maxPlayers; i++)
            if (playerAlive[i])
                playerCount++;

        if (playerCount < 2)
            return true;
        return false;
    }

    public void LockMouse()
    {
        mouseOn = false;
    }

    public void UnlockMouse()
    {
        if (!IsOver())
            mouseOn = true;
    }


    public void NextPlayer()
    {
        if(!IsOver())
        {
            do
            {
                currentPlayer++;
                if (currentPlayer >= maxPlayers)
                    currentPlayer = 0;
            } while (!playerAlive[currentPlayer]);
        }
    }    

    public void SetGameUpForBeginning()
    {
        currentPlayer = 0;
        GameInfoModule gim = FindObjectOfType<GameInfoModule>();

        if (gim)
            Debug.Log("Gim found");
        else
            Debug.Log("Where is gim?");


        if (gim)
            maxPlayers = gim.players;

        for (int i = 0; i < maxPlayers; i++)
            playerAlive[i] = true;

        mouseOn = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        SetGameUpForBeginning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
