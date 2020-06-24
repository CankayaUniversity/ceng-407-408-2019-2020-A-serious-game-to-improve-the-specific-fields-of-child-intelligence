using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class FocusColor : MonoBehaviour
{
    public SpriteRenderer[] colorbuttons;
    public SpriteRenderer[] focussprites;
    private Color[] colorlist = new Color[] { };
    public int correctcolor;
    public static int score = 0;
    Vector2 pos;
    Vector2 temppos;
    public Text scoretext = null;
    private ButtonHandler Bh;
    private int swapnum;
    public Text timetext;
    private float timestart = 60f;
    private float timenow;
    public bool gameended = false;
    public static int middlefinalscore;
    public Button nextgamebtn;
    public bool transfer = false;
    public Text leveltimetext;
    private float leveltime = 5f;
    private float leveltimenow;
    int tcnt = 0;
    int wcnt = 0;
    
    public bool gamestart = false;

    //------Data mining---------
    //records
    RecordsMM NEWrecords, OLDrecords;
    int playertype;
    //----------------------------



    public void CheckIfCorrect(int answerbutton)
    {
        if (correctcolor == answerbutton)
        {
            Debug.Log("Doğru");
            score = score + 2;
            scoretext.text = "Score: " + score;
            wcnt = 0;
            tcnt++;
            leveltimenow = leveltime;
            //------Data mining---------
            NEWrecords.TotalTrue++;
            //----------------------------


        }
        else
        {
            score--;
            scoretext.text = "Score: " + score;
            Debug.Log("Yanlış - Doğru cevap "+correctcolor);
            tcnt = 0;
            wcnt++;
            leveltimenow = leveltime;
            //------Data mining---------
            NEWrecords.TotalFalse++;
            //----------------------------
        }
        NEWrecords.RecordScore = (float)score;
        SwapClouds();
    }

    public void RandomMovement()
    {
        float xposition = Random.Range(-2f, 2f);
        float yposition = Random.Range(-2.5f, 2.5f);
        pos.x += xposition;
        pos.y += yposition;
        focussprites[0].transform.position = pos;
        pos.x = 0;
        pos.y = 0;
    }

    public void SwapClouds()
    {
        for (int i = 0; i < 4; i++)
        {
            swapnum = Random.Range(0,4);
            temppos = colorbuttons[i].transform.position;
            colorbuttons[i].transform.position = colorbuttons[swapnum].transform.position;
            colorbuttons[swapnum].transform.position = temppos;
        }
    }
    public void ChangeColors()
    {
        colorlist = new Color[4] { Color.red, Color.green, Color.blue, Color.magenta };
        correctcolor = Random.Range(0, 4);
        focussprites[0].GetComponent<SpriteRenderer>().color = colorlist[correctcolor];
        for (int i = 1; i < 5; i++)
        {
            focussprites[i].GetComponent<SpriteRenderer>().color = colorlist[Random.Range(0, 4)];
        }
    }

   
    void Awake()
    {
        nextgamebtn.gameObject.SetActive(false);
        score = 0;
        timestart = 60f;
        leveltime = 5f;

        //------Data mining---------
        NEWrecords = new RecordsMM();
        OLDrecords = new RecordsMM();
        
        string path = "/PlayerRecordsMM.json";

            OLDrecords = JsonUtility.FromJson<RecordsMM>(File.ReadAllText(Application.persistentDataPath + path));
            if (OLDrecords.result == 1)
            {
                leveltime = 6f;
                timestart = 65f;
                Debug.Log("player type : " + OLDrecords.result);
            }
            if (OLDrecords.result == 2)
            {
                leveltime = 4.5f;
                timestart = 55f;
                Debug.Log("player type : " + OLDrecords.result);
            }
            if (OLDrecords.result == 3)
            {
                leveltime = 4f;
                timestart = 50f;
                Debug.Log("player type : " + OLDrecords.result);
            }
            
            Debug.Log("Total OLDfalse = " + OLDrecords.TotalFalse);
            Debug.Log("Total OLDtrue = " + OLDrecords.TotalTrue);
            Debug.Log("Total OLDAvgReactTime = " + OLDrecords.AvgReactTime);
            Debug.Log("OLDRecordScore = " + OLDrecords.RecordScore);
            Debug.Log("OLDPlayerType = " + OLDrecords.PlayerType);
            Debug.Log("OLDresult = " + OLDrecords.result);

        
        //----------------------------




    }
    void Start()
    {
        leveltimenow = leveltime;
        if (gamestart)
        {
            ChangeColors();
        }
       

        timetext.text = "Time: " + timestart.ToString();

        leveltimetext.text = "" + leveltime.ToString();

        scoretext.text = "Score: " + score;
       
       //ChangeColors();
        
              
    }

    public void TransferScore()
    {
        if (transfer)
        {
            AllVar.routine_mode_score = AllVar.routine_mode_score + middlefinalscore;
            transfer = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        if (gamestart)
        {
            if (!gameended)
            {
                timestart -= Time.deltaTime;
                timenow = timestart;
                timetext.text = "Time: " + Mathf.Round(timenow).ToString();
                leveltimenow -= Time.deltaTime;
                leveltimetext.text = "" + Mathf.Round(leveltimenow).ToString();
            }
            if (Mathf.Round(timenow) == 0)
            {
                gameended = true;
                pos.x = 0;
                pos.y = 0;
                focussprites[0].transform.position = pos;
                timetext.text = "For Next Game!";
                scoretext.text = "Press The Arrow!";
                middlefinalscore = score;
                if (!SceneTransition.inselect)
                {
                    TransferScore();
                    transfer = false;
                }
                //-----------Data mining ---------
                NEWrecords.AvgReactTime = ((NEWrecords.TotalFalse + NEWrecords.TotalTrue) / 60f);
                NEWrecords.PushRecords(NEWrecords, OLDrecords);
                //----------------------------
                nextgamebtn.gameObject.SetActive(true);
            }
            if (Mathf.Round(leveltimenow)==0)
            {
                ChangeColors();
                leveltime += 1;
                leveltimenow = leveltime;

                
            }
            if (tcnt==3 && leveltime>=2)
            {
                leveltime -= 1;
                tcnt = 0;
            }
            if (wcnt==3)
            {
                
                leveltime += 1;
                wcnt = 0;
            }
        }
    }
}
