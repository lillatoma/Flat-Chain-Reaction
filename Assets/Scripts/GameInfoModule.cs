using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInfoModule : MonoBehaviour
{
    public int players = 2;

    public void ChangePlayerCount(TMP_Dropdown dropdown)
    {
        players = dropdown.value + 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
