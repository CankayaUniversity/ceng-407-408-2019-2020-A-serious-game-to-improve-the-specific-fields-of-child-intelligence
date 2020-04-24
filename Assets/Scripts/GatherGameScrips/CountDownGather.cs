using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDownGather : MonoBehaviour
{
    public int countdownTime;
    public Text countdowntext;
    SpawnObjects So;
    private void Start()
    {
        if (TuTorialHandler.tutorial_online)
        {
            countdownTime = 100;
        }
        So = FindObjectOfType<SpawnObjects>();
        StartCoroutine(CountdownStartGather());
    }
    IEnumerator CountdownStartGather()
    {
        while (countdownTime > 0)
        {

            countdowntext.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdowntext.text = "GO!";
        So.gamestart = true;


        yield return new WaitForSeconds(1f);
        countdowntext.gameObject.SetActive(false);

    }
}