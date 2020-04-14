using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    
    public void ToWardrobe()
    {
            SceneManager.LoadScene("Wardrobe");
    }

    public void ToRoutine()
    {
        SceneManager.LoadScene("MiddleMatters");
        
    }

    public void ToSelectGame()
    {
        Debug.Log("Select Game Mode !");
    }
}
