using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text goldtext;
    // Start is called before the first frame update
    void Start()
    {
        goldtext.text = "Your Gold: " + AllVar.totalgold.ToString() + ". Your Mascot number: " + AllVar.mascotindex;
    }


}
