using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MathGameManager : MonoBehaviour
{
    public Text[] numText = new Text[4];
    public int[] numbers = new int[4];

    public float time;
    public float timeLimit;

    public Text timeText;

    public Button[] buttons;

    public int[] answer;

    public int res;
    public int loc;

    public float score;
    public Text scoreText;

    public AudioSource src;
    public AudioClip[] clps = new AudioClip[2];
    void rng()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Random.RandomRange(0, 10);
            numText[i].text = numbers[i].ToString();

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        time = 0.1f;
        src = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Time: " + time.ToString("0");
        printResult();
        if (time<=0)
        {
            time = timeLimit;
            rng();
            res = (numbers[0] * numbers[1]) + numbers[2] - numbers[3];
            printResult();
            
            loc = locate();

            if (loc==0)   // correct answer is smallest number
            {
                answer[0] = res;
                answer[1] = res + Random.Range(1, 3);
                answer[2] = res + Random.Range(4, 7);
                Shuffle(answer);
            }
            else if (loc==1) // correct answer is middle number
           {
                answer[0] = res;
                answer[1] = res + Random.Range(1,6);
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
        for (int i = 0; i < buttons.Length; i++)
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
            buttons[choice].image.color = Color.green;
            score += 2*time;
            scoreText.text = "Score:" + score.ToString("0");
            src.PlayOneShot(clps[0]);
        }
        else
        {
            Debug.Log("Wrong");
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
}
