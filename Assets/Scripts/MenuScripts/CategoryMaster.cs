using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoryMaster : MonoBehaviour
{
    static public bool in_select_game_mode = false;
    public void ToMiddleMatters()
    {
        SceneManager.LoadScene("MiddleMatters");
        in_select_game_mode = true;
    }
    public void ToCardGame()
    {
        in_select_game_mode = true;
        
        SceneManager.LoadScene("CardGame");
    }
    public void ToGatherGame()
    {
        in_select_game_mode = true;
        Debug.Log(in_select_game_mode);
        SceneManager.LoadScene("GatherGame");
    }
    public void ToSimonSays()
    {
        in_select_game_mode = true;
        SceneManager.LoadScene("SimonSays");
    }

    public void ToFocusCategoty()
    {
        in_select_game_mode = true;
        SceneManager.LoadScene("Category_Focus");
    }

    public void ToColorsCategory()
    {
        in_select_game_mode = true;
        SceneManager.LoadScene("Category_EnjoytheColors");
    }

    public void ToMemoryCategory()
    {
        in_select_game_mode = true;
        SceneManager.LoadScene("Category_Memory");
    }

    public void ToFindYourWayCat()
    {
        in_select_game_mode = true;
        SceneManager.LoadScene("Category_FindYourWay");
    }

    public void ToMainMenu()
    {
        in_select_game_mode = true;
        SceneManager.LoadScene("MainMenuMindGarden");
    }
    public void ToBallGame()
    {
        in_select_game_mode = true;
        SceneManager.LoadScene("BallTilt");
    }

    public void ToPuzzleGame()
    {
        in_select_game_mode = true;
        SceneManager.LoadScene("Puzzle");
    }
}
