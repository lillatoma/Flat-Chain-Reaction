using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrentPlayerBar : MonoBehaviour
{

    public TMP_Text text;
    private Image image;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        image = FindObjectOfType<Image>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsOver())
        {
            image.color = gameManager.playerColors[gameManager.GetWinner()];
            text.text = gameManager.playerNames[gameManager.GetWinner()] + " has won";
        }
        else
        {
            image.color = gameManager.playerColors[gameManager.currentPlayer];
            text.text = gameManager.playerNames[gameManager.currentPlayer] + "'s turn";
        } }
}
