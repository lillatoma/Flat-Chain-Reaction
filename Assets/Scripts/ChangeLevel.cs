using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{

    public void StartGame()
    {
        DontDestroyOnLoad(FindObjectOfType<GameInfoModule>());
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        Destroy(FindObjectOfType<GameInfoModule>().gameObject);
        //FindObjectOfType<GameInfoModule>().transform.parent = null;
        SceneManager.LoadScene("MainMenu");
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
