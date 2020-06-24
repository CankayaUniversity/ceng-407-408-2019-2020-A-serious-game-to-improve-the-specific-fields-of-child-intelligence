using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer[] color;
    public AudioSource[] sounds;

    private int select;
    public float stay=1f;
    private float stayCounter;
    public float waitLight;
    private float waitCounter;
    private Text levelText;
    private bool beLit;
    private bool beDark;
    private int level;
    public List<int> sequence;
    private int index;
    private bool gameActive;
    private int input;
    public bool stop = false;
    public AudioSource correct;
    public AudioSource incorrect;
    public Button nextgamebtn;
    public Text scoreText;
    public Button startgamebtn;
    public static int simon_score;
    void Start()
    {
        nextgamebtn.gameObject.SetActive(false);
        if (!PlayerPrefs.HasKey("HiScore"))
        {
            PlayerPrefs.SetInt("HiScore", 0);
        }
        scoreText.text = "Score: 0" + Environment.NewLine + "High Score: " + PlayerPrefs.GetInt("HiScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (beLit)
        {
            stayCounter -= Time.deltaTime;

            if (stayCounter < 0)
            {
                color[sequence[index]].color = new Color(color[sequence[index]].color.r, color[sequence[index]].color.g, color[sequence[index]].color.b, 0.5f);
                sounds[sequence[index]].Stop();
                beLit = false;

                beDark = true;
                waitCounter = waitLight;

                index++;
            }
        }
        if (beDark)
        {
            waitCounter -= Time.deltaTime;
            if (index >= sequence.Count)
            {
                beDark = false;
                gameActive = true;
            }
            else
            {
                if (waitCounter < 0)
                {

                    color[sequence[index]].color = new Color(color[sequence[index]].color.r, color[sequence[index]].color.g, color[sequence[index]].color.b, 1f);
                    sounds[sequence[index]].Play();
                    stayCounter = stay;
                    beLit = true;
                    beDark = false;
                }
            }
        }

    }
    public void StartGame()
    {
        startgamebtn.gameObject.SetActive(false);
        sequence.Clear();
        index = 0;
        input = 0;
        select = UnityEngine.Random.Range(0, 4);
        sequence.Add(select);
        color[sequence[index]].color = new Color(color[sequence[index]].color.r, color[sequence[index]].color.g, color[sequence[index]].color.b, 1f);
        sounds[sequence[index]].Play();
        stayCounter = stay;
        beLit = true;

        scoreText.text = "Score: 0" + Environment.NewLine + "High Score: "  + PlayerPrefs.GetInt("HiScore");

    }
    public void ColourPressed(int whichButton)
    {
        if (gameActive)
        {
            if (sequence[input] == whichButton)
            {
                Debug.Log("Correct");

                input++;
                if (input >= sequence.Count)
                {
                    if (sequence.Count > PlayerPrefs.GetInt("HiScore"))
                    {
                        PlayerPrefs.SetInt("HiScore", sequence.Count);
                    }
                    scoreText.text = "Score: " + sequence.Count + Environment.NewLine + "High Score: " + PlayerPrefs.GetInt("HiScore");
                    index = 0;
                    input = 0;
                    select = UnityEngine.Random.Range(0, 4);
                    sequence.Add(select);
                    color[sequence[index]].color = new Color(color[sequence[index]].color.r, color[sequence[index]].color.g, color[sequence[index]].color.b, 1f);
                    sounds[sequence[index]].Play();
                    stay -= 0.1f;
                    stayCounter = stay;
                    beLit = true;
                    gameActive = false;
                    correct.Play();

                }
            }
            else
            {
                nextgamebtn.gameObject.SetActive(true);
                simon_score = sequence.Count;
                if (!SceneTransition.inselect)
                {
                    AllVar.routine_mode_score = AllVar.routine_mode_score + simon_score * 5 - 5;
                }
               
                incorrect.Play();
                stop = true;
                gameActive = false;
            }
        }
    }
}