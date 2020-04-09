using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField] private Transform cardField;

    [SerializeField] private GameObject but;
    private void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject button = Instantiate(but);
            button.name = "" + i;
            button.transform.SetParent(cardField, false);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
