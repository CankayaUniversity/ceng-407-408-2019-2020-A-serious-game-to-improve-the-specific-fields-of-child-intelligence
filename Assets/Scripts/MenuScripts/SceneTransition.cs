using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneTransition : MonoBehaviour
{
    public Animator transition;
    public static int scenenum = -2;
    public static bool routine_array_created = true;
    private static int[] scene_order = new int[4];
    private static int[] temp_arr = new int[7];
    int i = 0;
    int d;
    int holder;
    int temp;
    public static bool routine_online = true;
    public static bool inselect = false;
    public GameObject tutorialprefab;

    // Update is called once per frame

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            TuTorialHandler.tutorial_online = false;
        }
        Debug.Log("Tutorial Flag: " + TuTorialHandler.tutorial_online);
        Debug.Log("Routine Flag: " + routine_online);
        for (int i = 0; i < 7; i++)
        {
            temp_arr[i] = i;
           
        }
        
    }
    public void LoadRoutine()
    {
        
        if (inselect)
        {
            inselect = false;                                         //To determine if current game is in select mode or routine mode.
            StartCoroutine(LoadAnimationRoutine());
        }
       else if (routine_array_created)
        {
            tutorialprefab.gameObject.SetActive(false);              //So that routine mode can be played only once, one pattern is enough
            i = 0;
            d = 7;
            while (i < 4)
            {
                holder = Random.Range(1, d);
                scene_order[i] = temp_arr[holder];
                temp = temp_arr[holder];
                temp_arr[holder] = temp_arr[d - 1];
                temp_arr[d - 1] = temp;
                d--;
                i++;
            }
            Debug.Log(scene_order[0]);
            Debug.Log(scene_order[1]);
            Debug.Log(scene_order[2]);
            Debug.Log(scene_order[3]);
            routine_array_created = false;
            StartCoroutine(LoadAnimationRoutine());
        }
        StartCoroutine(LoadAnimationRoutine());
    }
       
    
    IEnumerator LoadAnimationRoutine()
    {
        
        if (inselect)
        {
            StartCoroutine(LoadAnimation(0));            //For select game mode.
        }
        scenenum++;
        if (scenenum < 4)
        {
            transition.SetTrigger("Start");               //If routine mode keeps going.
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(scene_order[scenenum]);
        }
        else
        {                                                 //If last game of routine mode was played.
            routine_online = false;
            StartCoroutine(LoadAnimation(0));
        }
    }

    IEnumerator LoadAnimation(int x)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);             // For scene transition animation.
        SceneManager.LoadScene(x);
    }
    public void LoadWardrobe()
    {
        StartCoroutine(LoadAnimation(8));                // Functions above are on-click events for scene transition.
    }

    public void LoadBack()
    {
        inselect = false;
        StartCoroutine(LoadAnimation(0));
    }

    public void LoadSelectGame()
    {
        TuTorialHandler.tutorial_online = true;
        StartCoroutine(LoadAnimation(13));
    }

    public void LoadFocus()
    {
        StartCoroutine(LoadAnimation(9));
    }
    public void EnjoyColors()
    {
        StartCoroutine(LoadAnimation(12));
    }
    public void Memory()
    {
        StartCoroutine(LoadAnimation(10));
    }
    public void FindWay()
    {
        StartCoroutine(LoadAnimation(11));
    }
    public void LoadMiddleMatters()
    {
        inselect = true;
        StartCoroutine(LoadAnimation(1));
    }

    public void LoadSimonSays()
    {
        inselect = true;
        StartCoroutine(LoadAnimation(2));
    }
    public void LoadCardGame()
    {
        inselect = true;
        StartCoroutine(LoadAnimation(3));
    }
    public void LoadGatherGame()
    {
        inselect = true;
        StartCoroutine(LoadAnimation(4));
    }
    public void LoadPuzzleGame()
    {
        inselect = true;
        StartCoroutine(LoadAnimation(5));
    }
    public void LoadBallGame()
    {
        inselect = true;
        StartCoroutine(LoadAnimation(7));
    }

    public void LoadMathGame()
    {
        inselect = true;
        StartCoroutine(LoadAnimation(6));
    }
}
