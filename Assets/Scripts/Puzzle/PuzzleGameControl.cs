using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleGameControl : MonoBehaviour
{
    [SerializeField] private Transform[] pictures;

    [SerializeField] private GameObject winnerText;

    public static bool youWin;

    public float timer;

    public Text timeText;

    public Button nextgamebtn;

    public int score = 0;

    bool transferflag = true;


    void Start()
    {
        nextgamebtn.gameObject.SetActive(false);
        //Shufle();
        winnerText.SetActive(false);
        youWin = false;
    }

    public void WinGame()
    {
        youWin = true;
    }

    public void TransferScore()
    {
        if (transferflag)
        {
            score = (int)timer;
            score = 50 - score;
            AllVar.routine_mode_score = AllVar.routine_mode_score + 2 * score;
            transferflag = false;
        }
    }
   
    void Update()
    {
        if (!youWin)
        {
            timer += Time.deltaTime;
            timeText.text = " Time: " + (int)timer;
        }
        timeText.text = " Time: " + (int)timer;
        if (pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0 &&
            pictures[4].rotation.z == 0 &&
            pictures[5].rotation.z == 0 )
        {
            youWin = true;
            if (!SceneTransition.inselect)
            {
                TransferScore();
            }
          
            
            winnerText.SetActive(true);
            nextgamebtn.gameObject.SetActive(true);

        }
       
    }

    void Shufle()
    {
        for (int i = 0; i < 6; i++)
        {
            pictures[i].transform.Rotate(0, 0, Random.Range(0, 3) * 90);
        }
    }
}
