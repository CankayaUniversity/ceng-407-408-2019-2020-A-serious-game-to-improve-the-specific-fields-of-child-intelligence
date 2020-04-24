using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUı;
   
    public void pauseGame()
    {
        pauseMenuUı.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void resumeGame()
    {
        pauseMenuUı.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void returnMenu()
    {
      
        FindObjectOfType<SceneTransition>().LoadBack();
        pauseMenuUı.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
