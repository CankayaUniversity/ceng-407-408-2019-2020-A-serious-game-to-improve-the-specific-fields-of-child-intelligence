using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDown : MonoBehaviour
{
    public int countdownTime;
    public Text countdowntext;
    public GameObject focus;
    FocusColor Fc;

    private void Start()
    {
        if (TuTorialHandler.tutorial_online)
        {
            countdownTime = 100;
        }
        StartCoroutine(CountdownStart());
    }


    IEnumerator CountdownStart()
    {
        while (countdownTime > 0)
        {
            
            countdowntext.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdowntext.text = "GO!";
       
        Fc = FindObjectOfType<FocusColor>();
        

        yield return new WaitForSeconds(1f);
        focus.SetActive(true);
        Fc.gamestart = true;
        Fc.ChangeColors();
        countdowntext.gameObject.SetActive(false);

    }
}

