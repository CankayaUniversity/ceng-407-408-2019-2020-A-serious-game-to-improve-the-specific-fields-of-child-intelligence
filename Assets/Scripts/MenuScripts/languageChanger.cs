using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class languageChanger : MonoBehaviour
{
    [SerializeField] GameObject[] allText;

    [SerializeField] int numOfText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < numOfText; i++)
        {
            allText[i].SetActive(false);
            allText[i].SetActive(true);
        }
    }
}
