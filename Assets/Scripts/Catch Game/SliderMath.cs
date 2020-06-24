using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SliderMath : MonoBehaviour
{
    public Text gameScore;
    public Text avgNum;
    public float score;
    public float time;
    public float timeLimit;
    public float currentTime = 0f;
    public float startingTime = 45f;
    public Text timerText;
    private RuntimePlatform platform = Application.platform;
    private GameObject numberObject1;
    private GameObject numberObject2;
    public float velocity = 1.0f;
    public GameObject attackText;
    public int attack;
    public int cnt = 0;
    public AudioSource source;
    public AudioClip[] clips = new AudioClip[2];
    public Button[] butt;
    [SerializeField]
    public GameObject trueText;
    [SerializeField]
    public Button nextgamebtn;
    public GameObject wrongText;
    public GameObject spawncript;
    public GameObject[] monsters;
    public GameObject startButton;
    public static bool gameActive = false;

    //-------------------Data Mining-----------------
    public RecordsMG OLDrecords, NewRecords;
    //---------------
    
    private void Awake()
    {
        spawncript.GetComponent<Spawner>().enabled = false;
    }
    void Start()
    {
        gameActive = false;
        //----------------------Data Mining ------------------------
        OLDrecords = new RecordsMG();
        NewRecords = new RecordsMG();
        string path = "/PlayerRecordsMG.json";
        OLDrecords = JsonUtility.FromJson<RecordsMG>(File.ReadAllText(Application.persistentDataPath + path));

        Debug.Log("Total OLDfalse = " + OLDrecords.TotalFalse);
        Debug.Log("Total OLDtrue = " + OLDrecords.TotalTrue);
        Debug.Log("Total OLDAvgReactTime = " + OLDrecords.AvgReactTime);
        Debug.Log("OLDRecordScore = " + OLDrecords.RecordScore);
        Debug.Log("OLDPlayerType = " + OLDrecords.PlayerType);
        Debug.Log("OLDresult = " + OLDrecords.result);

        if (OLDrecords.result == 1)
        {
            startingTime = 50f;
            velocity = 1.0f;
            Debug.Log("player type Begginer: " + OLDrecords.result);
        }
        if (OLDrecords.result == 2)
        {
            startingTime = 45f;
            velocity = 3.0f;
            Debug.Log("player type Intermediate: " + OLDrecords.result);
        }
        if (OLDrecords.result == 3)
        {
            startingTime = 40f;
            velocity = 9.0f;
            Debug.Log("player type Proffesional: " + OLDrecords.result);
        }

        //----------------------------


        //Time.timeScale = 0f;
        //  spawncript.GetComponent<Spawner>().enabled = false;
        nextgamebtn.gameObject.SetActive(false);
        source = gameObject.AddComponent<AudioSource>();
        currentTime = startingTime;
        butt[0].gameObject.SetActive(false);
        butt[1].gameObject.SetActive(false);
        butt[2].gameObject.SetActive(false);
        avgNum.gameObject.SetActive(false);
        //butt[0].interactable = false;
        //butt[1].interactable = false;

    }
    void Update()
    {
        if (gameActive)
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = "Time: " + currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
            }
            if (currentTime == 0)
            {
                nextgamebtn.gameObject.SetActive(true);
                stopGame();
            }
            if (platform == RuntimePlatform.Android)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        checkTouch(Input.GetTouch(0).position);
                    }
                }
            }
            else if (platform == RuntimePlatform.WindowsEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    checkTouch(Input.mousePosition);
                }
            }
            for (int i = 0; i < butt.Length; i++)
            {
                butt[i].image.color = Color.white;
            }
        }
    }

    void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if (hit)
        {

            if (hit.transform.gameObject.tag == "number")
            {
                cnt++;
                //avgNum.gameObject.SetActive(true);
                //butt[0].gameObject.SetActive(true);
                //butt[1].gameObject.SetActive(true);
                //butt[2].gameObject.SetActive(true);
                if (!this.numberObject1)
                {
                    this.numberObject1 = hit.transform.gameObject;
                    this.numberObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

                }
                else if (this.numberObject1 == hit.transform.gameObject)
                {

                    this.numberObject1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -this.velocity);
                    this.numberObject1 = null;
                }
                else if (this.numberObject1 != hit.transform.gameObject)
                {

                    this.numberObject2 = hit.transform.gameObject;
                    this.numberObject1.SendMessage("operated", 0, SendMessageOptions.DontRequireReceiver);
                    this.numberObject2.SendMessage("operated", 0, SendMessageOptions.DontRequireReceiver);
                    this.operation(this.numberObject1, this.numberObject2);
                    attack = int.Parse(this.numberObject1.name) + int.Parse(this.numberObject2.name);
                    Debug.Log(attack);
                    this.numberObject1 = null;
                    this.numberObject2 = null;


                }
            }
        }
        if (cnt % 2 == 0)
        {
            avgNum.gameObject.SetActive(true);
            butt[0].gameObject.SetActive(true);
            butt[1].gameObject.SetActive(true);
            butt[2].gameObject.SetActive(true);
        }
        //butt[0].gameObject.SetActive(true);
        //butt[1].gameObject.SetActive(true);
        //butt[0].interactable = true;
        //butt[1].interactable = true;
    }

    void operation(GameObject operand1, GameObject operand2)
    {

    }

    void menuClicked()
    {
        Debug.Log("click");
    }

    IEnumerator instantiateAttackText(int attack, float timer)
    {
        yield return new WaitForSeconds(timer);
        Vector2 position = new Vector2(0, 6);
        GameObject x = Instantiate(attackText, position, Quaternion.identity);
        x.name = attack.ToString();
        x.GetComponent<TextMesh>().text = attack.ToString();
        StartCoroutine(launchAtack(x, attack, 0.25f));
    }

    IEnumerator launchAtack(GameObject attackText, int attack, float timer)
    {
        yield return new WaitForSeconds(timer);
        int attackVelo = (attack <= 10) ? 8 : -8;
        Rigidbody2D velo = attackText.GetComponent<Rigidbody2D>();
        velo.velocity = new Vector2(0, attackVelo);

        Destroy(attackText, 2.0f);
    }
    public void PauseAndResume()
    {
        Time.timeScale = 0;
        StartCoroutine(ResumeAfterNSeconds(1.0f));
    }

    float timer = 0;
    IEnumerator ResumeAfterNSeconds(float timePeriod)
    {
        yield return new WaitForEndOfFrame();
        timer += Time.unscaledDeltaTime;
        if (timer < timePeriod)
            StartCoroutine(ResumeAfterNSeconds(1.0f));
        else
        {
            Time.timeScale = 1;
            timer = 0;
        }
    }
    public void upSide()
    {

        if (attack < 10)
        {
            Debug.Log("Correct");
            source.PlayOneShot(clips[0]);
            butt[0].image.color = Color.green;
            wrongText.SetActive(false);
            trueText.SetActive(true);
            score += 20;
            gameScore.text = "Score: " + score.ToString("0");
            //------Data Mining---------
            NewRecords.TotalTrue++;
            //------------------

        }
        else
        {
            Debug.Log("Wrong");
            source.PlayOneShot(clips[1]);
            butt[0].image.color = Color.red;
            trueText.SetActive(false);
            wrongText.SetActive(true);
            if (score >= 20)
            {
                score -= 20;
            }
            else if (score < 20)
            {
                score = 0;
            }
            gameScore.text = "Score: " + score.ToString("0");
            //------Data Mining---------
            NewRecords.TotalFalse++;
            //------------------
        }
        StartCoroutine(instantiateAttackText(attack, 1f));
        butt[0].gameObject.SetActive(false);
        butt[1].gameObject.SetActive(false);
        butt[2].gameObject.SetActive(false);
        avgNum.gameObject.SetActive(false);
        //butt[0].interactable = false;
        //butt[1].interactable = false;


    }
    public void downSide()
    {

        if (attack > 10)
        {
            Debug.Log("Correct");
            source.PlayOneShot(clips[0]);
            butt[1].image.color = Color.green;
            wrongText.SetActive(false);
            trueText.SetActive(true);
            score += 20;
            gameScore.text = "Score: " + score.ToString("0");
            //------Data Mining---------
            NewRecords.TotalTrue++;
            //------------------
        }
        else
        {
            Debug.Log("Wrong");
            source.PlayOneShot(clips[1]);
            butt[1].image.color = Color.red;
            trueText.SetActive(false);
            wrongText.SetActive(true);
            if (score >= 20)
            {
                score -= 20;
            }
            else if (score < 20)
            {
                score = 0;
            }
            gameScore.text = "Score: " + score.ToString("0");
            //------Data Mining---------
            NewRecords.TotalFalse++;
            //------------------
        }
        StartCoroutine(instantiateAttackText(attack, 1f));
        butt[0].gameObject.SetActive(false);
        butt[1].gameObject.SetActive(false);
        butt[2].gameObject.SetActive(false);
        avgNum.gameObject.SetActive(false);


    }
    public void equalTo()
    {

        if (attack == 10)
        {
            Debug.Log("Correct");
            source.PlayOneShot(clips[0]);
            butt[0].image.color = Color.green;
            wrongText.SetActive(false);
            trueText.SetActive(true);
            score += 20;
            gameScore.text = "Score: " + score.ToString("0");
            //------Data Mining---------
            NewRecords.TotalTrue++;
            //------------------
        }
        else
        {
            Debug.Log("Wrong");
            source.PlayOneShot(clips[1]);
            butt[0].image.color = Color.red;
            trueText.SetActive(false);
            wrongText.SetActive(true);
            if (score >= 20)
            {
                score -= 20;
            }
            else if (score < 20)
            {
                score = 0;
            }
            gameScore.text = "Score: " + score.ToString("0");
            //------Data Mining---------
            NewRecords.TotalFalse++;
            //------------------

        }
        StartCoroutine(instantiateAttackText(attack, 1f));
        butt[0].gameObject.SetActive(false);
        butt[1].gameObject.SetActive(false);
        butt[2].gameObject.SetActive(false);
        avgNum.gameObject.SetActive(false);
        //butt[0].interactable = false;
        //butt[1].interactable = false;


    }
    public void stopGame()
    {

        monsters = GameObject.FindGameObjectsWithTag("number");
        foreach(GameObject m in monsters)
        {
            Destroy(m);
        }

        spawncript.GetComponent<Spawner>().enabled = false;
        NewRecords.AvgReactTime = ((NewRecords.TotalFalse + NewRecords.TotalTrue) / startingTime);
        NewRecords.RecordScore = score;
        NewRecords.PushRecords(NewRecords, OLDrecords);

    }

    public void collideAnother()
    {

        if (score >= 10)
        {
            score -= 10;
        }
        else if (score < 10)
        {
            score = 0;
        }
        gameScore.text = "Score: " + score.ToString("0");
    }

    IEnumerator waitfortuto()
    {
        yield return new WaitForSeconds(2.2f);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
       
        gameActive = true;
        spawncript.GetComponent<Spawner>().enabled = true;
        startButton.SetActive(false);
    }
}

