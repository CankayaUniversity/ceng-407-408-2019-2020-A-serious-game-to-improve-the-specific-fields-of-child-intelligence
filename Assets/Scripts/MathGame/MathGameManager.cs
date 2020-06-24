using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MathGameManager : MonoBehaviour
{
    public Text[] numText = new Text[4];
    public int[] numbers = new int[4];

    public float time;
    public float timeLimit=10f;

    public Text timeText;

    public Button[] buttons;

    public int[] answer;

    public int res;
    public int loc;
    public int tcnt=0;
    public int wcnt = 0;

    GameObject[] platforms;
    MovePlatform mp;

    public float score;
    public Text scoreText;
    public GameObject moving_platforms;
    public bool gamestarted = false;
    public bool gameended = false;
    private float timestart = 60f;
    public Button nextgamebtn;
    public Text timetext;
    private float timenow;
    public Text platform_speed_txt;
    public AudioSource src;
    public AudioClip[] clps = new AudioClip[2];

    //----------Data Mining----------
    //difficulty record
    public float TotalAnsNum;
    public int TimeResCount;
    public Records records, OLDrecords;
    public float AvgReactTime;
    public float TotalTrue;
    public float TotalFalse;
    public float SumOfAns;
    public float NotInTime;
    public float RecordScore;
    public float PlayerType;
    public int temp;
    //----------------------------

    void rng()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            //----------Data Mining----------
            numbers[i] = Random.RandomRange(0, temp);
            //----------------------------
            numText[i].text = numbers[i].ToString();

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        
        mp = FindObjectOfType<MovePlatform>();
        for (int i = 0; i < 3; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
        moving_platforms.gameObject.SetActive(false);
        nextgamebtn.gameObject.SetActive(false);
        time = 0.1f;
            src = gameObject.AddComponent<AudioSource>();

        //----------------------Data mining-------------
        OLDrecords = new Records();
        records = new Records();
        string path = "/PlayerRecords.json";
        OLDrecords = JsonUtility.FromJson<Records>(File.ReadAllText(Application.persistentDataPath + path));
        Debug.Log("Total OLDfalse = " + OLDrecords.TotalFalse);
        Debug.Log("Total OLDtrue = " + OLDrecords.TotalTrue);
        Debug.Log("Total OLDAvgReactTime = " + OLDrecords.AvgReactTime);
        Debug.Log("Total OLDSumOfAns = " + OLDrecords.SumOfAns);
        Debug.Log("OLDPlayerType = " + OLDrecords.PlayerType);
        Debug.Log("OLDRecordScore = " + OLDrecords.RecordScore);

        OLDrecords.Detect_Type(OLDrecords);

        if (OLDrecords.result == 1)
        {
            temp = 10;
            timestart = 60f;
        }
        if (OLDrecords.result == 2)
        {
            temp = 12;
            timestart = 55f;
        }
        if (OLDrecords.result == 3)
        {
            temp = 14;
            timestart = 50f;
        }
        //----------------------------


    }

    // Update is called once per frame
    void Update()
    {
        if (gamestarted)
        {
            if (!gameended)
            {
                timestart -= Time.deltaTime;
                timenow = timestart;
                timetext.text = "Count Down: " + Mathf.Round(timenow).ToString();
            }
            if (Mathf.Round(timenow) == 0)
            {
                gameended = true;
                nextgamebtn.gameObject.SetActive(true);
                if (!SceneTransition.inselect)
                {
                    AllVar.routine_mode_score = AllVar.routine_mode_score + (int)score;
                }
               
                StopGame();
            }

            time -= Time.deltaTime;
            timeText.text = "Time: " + time.ToString("0");
            printResult();
            if (time <= 0)
            {
                time = timeLimit;
                rng();
                res = (numbers[3] * numbers[2]) + numbers[1] - numbers[0];
                //res = (numbers[0] * numbers[1]) + numbers[2] - numbers[3];
                printResult();

                loc = locate();

                if (loc == 0)   // correct answer is smallest number
                {
                    answer[0] = res;
                    answer[1] = res + Random.Range(1, 3);
                    answer[2] = res + Random.Range(4, 7);
                    Shuffle(answer);
                }
                else if (loc == 1) // correct answer is middle number
                {
                    answer[0] = res;
                    answer[1] = res + Random.Range(1, 6);
                    answer[2] = res - Random.Range(1, 6);
                    Shuffle(answer);
                }

                else  // correct answer is biggest number
                {
                    answer[0] = res;
                    answer[1] = res - Random.Range(1, 3);
                    answer[2] = res - Random.Range(4, 7);
                    Shuffle(answer);
                }

                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].image.color = Color.white;
                }

               
            }
            if (tcnt==3)
            {
                Debug.Log("hızlan");
                
                timeLimit -= 2f;
                tcnt = 0;
            }

            if (wcnt == 3)
            {
                Debug.Log("yavaşla");
               
                timeLimit += 2f;
                wcnt = 0;
            }
        }
        
    }



    public static void Shuffle<T>(T[] array)
    {
        for (int i = array.Length-1;i>0 ;  i--)
        {
            int ran = Random.Range(0, i+1);
            T temp = array[i];
            array[i] = array[ran];
            array[ran] = temp;
        }

    }
    void printResult()
    {
        for (int i = 0; i < buttons.Length -1; i++)
        {
            buttons[i].transform.GetChild(0).GetComponent<Text>().text = answer[i].ToString();
        }
    }

    int locate()
    {
       return Random.Range(0, 3);
    }

   public void checkAnswer(int choice)
    {
      if ( buttons[choice].transform.GetChild(0).GetComponent<Text>().text == res.ToString())
        {
            Debug.Log("Correct");
            wcnt = 0;
            buttons[choice].image.color = Color.green;
            score += 2*time;
            scoreText.text = "Score:" + score.ToString("0");
            src.PlayOneShot(clps[0]);
            tcnt++;
            //------------Data mining-------------
            TotalTrue++;
            //----------------------------
            Debug.Log(tcnt);
        }
        else
        {
            Debug.Log("Wrong");
            tcnt = 0;
            wcnt++;
            //------------Data mining-------------
            TotalFalse++;
            //----------------------------
            buttons[choice].image.color = Color.red;
            src.PlayOneShot(clps[1]);
            if (score>=10)
            {
               score -= 10;
            }
            else if (score<10)
            {
                score = 0;
            }
            scoreText.text = "Score:" + score.ToString("0");
        }
        time = 0.3f;
    }

    public void StartGame()
    {
        for (int i = 0; i < 3; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
        moving_platforms.gameObject.SetActive(true);
        gamestarted = true;
        buttons[3].gameObject.SetActive(false);
    }

    public void StopGame()
    {
        for (int i = 0; i < 3; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
        moving_platforms.gameObject.SetActive(false);
        gamestarted = false;

        //------------Data mining-------------
        PushRecords();
        //----------------------------
    }

    //------------Data mining-------------
    public void PushRecords()
    {

        TotalAnsNum = TotalFalse + TotalTrue;
        NotInTime = TimeResCount - TotalAnsNum;
        TotalFalse = TotalFalse + NotInTime;
        TotalAnsNum = TotalFalse + TotalTrue;
        AvgReactTime = TotalAnsNum / 60f;
        PlayerType = ((TotalFalse + TotalTrue + AvgReactTime + SumOfAns + RecordScore) / 5);

        records.PlayerType = Euclidean_Distance(OLDrecords.PlayerType, PlayerType);
        records.TotalFalse = Euclidean_Distance(OLDrecords.TotalFalse, TotalFalse);
        records.TotalTrue = Euclidean_Distance(OLDrecords.TotalTrue, TotalTrue);
        records.AvgReactTime = Euclidean_Distance(OLDrecords.AvgReactTime, AvgReactTime);
        records.SumOfAns = Euclidean_Distance(OLDrecords.SumOfAns, SumOfAns);
        records.RecordScore = Euclidean_Distance(OLDrecords.RecordScore, RecordScore);
        records.Detect_Type(records);


        Debug.Log(Application.persistentDataPath);
        Debug.Log("Total false = " + records.TotalFalse);
        Debug.Log("Total true = " + records.TotalTrue);
        Debug.Log("Total AvgReactTime = " + records.AvgReactTime);
        Debug.Log("Total SumOfAns = " + records.SumOfAns);
        Debug.Log("RecordScore = " + RecordScore);
        Debug.Log("PlayerType = " + PlayerType);

        string path = "/PlayerRecords.json";
        string jsonData = JsonUtility.ToJson(records, true);
        File.WriteAllText(Application.persistentDataPath + path, jsonData);


    }
    public static float Euclidean_Distance(float x1, float x2)
    {
        return Mathf.Sqrt((x1 - x2) * (x1 - x2));
    }
    //----------------------------
}
