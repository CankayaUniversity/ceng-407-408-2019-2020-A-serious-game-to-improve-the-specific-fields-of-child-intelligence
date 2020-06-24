using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Sprite cardBg;

    public List<Button> button = new List<Button>();

    public List<Button> hintarray = new List<Button>();

    public Sprite[] cards;

    public List<Sprite> gameCards = new List<Sprite>();

    public List<Sprite> hintgameCards = new List<Sprite>();

    private bool firstSelect;
        
    private bool secondSelect;

    private int countSelect;

    private int countCorrects;

    private int finishGuess;

    private int firstSelectIndex;

    private int secondSelectIndex;

    private string firstSelectCard, secondSelectCard;

    public GameObject particles;

    public Button nextbtn;

    public float timer;

    public Text timeText;

    int[] pairs;

    public int score;

    string firstHint,secondHint;

    public  int cn1 = 0;
    public  int cn2 = 0;
    public bool isFinished = false;

     
    //public void GiveHint()
    //{
    //    for (cn1 = 0; cn1 < 12; cn1++)
    //    {
    //        for (cn2 = 0; cn2 < 12; cn2++)
    //        {
    //            if (gameCards[cn1].name == gameCards[cn2].name)
    //            {
    //                Debug.Log(gameCards[cn1].name);
    //                Debug.Log(gameCards[cn2].name);
    //                button[cn1].image.color = Color.red;
    //                button[cn2].image.color = Color.red;
    //                break;
    //            }
    //            break;
    //        }
    //    }
    //}


    void GetButton()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("CardTag");

        for (int i = 0; i < cards.Length ; i++)
        {
            button.Add(cards[i].GetComponent<Button>());
            button[i].image.sprite = cardBg;
        }
            }

    void AddGameCards()
    {
        int looper = button.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if(index== looper / 2)
            {
                index = 0;
            }
            gameCards.Add(cards[index]);
            index++;
        }

    }
    void AddListen()
    {
        foreach (Button btn in button)
        {
            btn.onClick.AddListener(() => SelectCard());
        }
    }
    public void SelectCard()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstSelect)
        {
            firstSelect = true;

            firstSelectIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstSelectCard = gameCards[firstSelectIndex].name;

            button[firstSelectIndex].image.sprite = gameCards[firstSelectIndex];
        }else if (!secondSelect)
        {
            secondSelect = true;

            secondSelectIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondSelectCard = gameCards[secondSelectIndex].name;

            button[secondSelectIndex].image.sprite = gameCards[secondSelectIndex];

            countSelect++;

            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);
        if (firstSelectCard == secondSelectCard)
        { 
           
            yield return new WaitForSeconds(.5f);
           
            button[firstSelectIndex].interactable = false;
            button[secondSelectIndex].interactable = false;
        
            button[firstSelectIndex].image.color = new Color(0,0,0,0);
            button[secondSelectIndex].image.color = new Color(0, 0, 0, 0);

            CheckFinish();
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            button[firstSelectIndex].image.sprite = cardBg;
            button[secondSelectIndex].image.sprite = cardBg;
        }
        yield return new WaitForSeconds(.5f);
        firstSelect = false;
        secondSelect = false;
    }

    void CheckFinish()
    {
        countCorrects++;
        if (countCorrects == finishGuess)
        {
            Debug.Log("game finished");
            isFinished = true;
            nextbtn.gameObject.SetActive(true);
            particles.SetActive(true);
            Debug.Log("it took "+countSelect+"guess");

            if (countSelect <= 10)
            {
                score = 100;
            }
            else if (countSelect <= 20)
            {
                score = 80;
            }
            else if (countSelect <= 30)
            {
                score = 60;
            }
            else
                score = 40;


            if (!SceneTransition.inselect)
            {
                AllVar.routine_mode_score = AllVar.routine_mode_score + score;
            }
            
          
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i=0; i<list.Count; i++)
        {
            Sprite temp = list[i];
            int rngIndex = Random.Range(i,list.Count);
            list[i] = list[rngIndex];
            list[rngIndex] = temp;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        GetButton();
        AddListen();
        AddGameCards();
        finishGuess = gameCards.Count / 2;
        Shuffle(gameCards);
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            timer += Time.deltaTime;
            timeText.text = " Time: " + (int)timer;
        }
    }
}
