using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour
{
    Collision C;
    private bool selectmode = false;
    CategoryMaster Cm;
    private Vector2 screenbounds;
    public Transform fallenobj1prefab_1;
    public Transform fallenobj1prefab_2;
    float xpos;
    float ypos;
    int which_to_spawn = 0;
    Transform point;
    int spawned_number = 0;
    public bool gamestart = false;
    public bool gameended = false;
    private float timestart = 60f;
    private float timenow;
    public Text timetext;
    public GameObject nextgame;
    Coroutine spawnRoutine = null;
    CountDownGather CDG;
    Basket B;
    public Button gatherbtn;
    
    private void SpawnObj()
    {
        if (gamestart)
        {
            xpos = Random.Range(-2f, +2f);
            ypos = Random.Range(5f, 7f);
            C = FindObjectOfType<Collision>();
            which_to_spawn = Random.Range(1, 3);
            if (which_to_spawn == 1)
            {
                point = Instantiate(fallenobj1prefab_1);
            }
            else
            {
                point = Instantiate(fallenobj1prefab_2);
            }
            point.transform.position = new Vector2(xpos, ypos);
            xpos = 0;
            ypos = 0;
            spawned_number++;
        }
        else
        {

        }
     
    }
    IEnumerator ObjectFall()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            SpawnObj();
        }
    }
    void Awake()
    {
        B = FindObjectOfType<Basket>();
        nextgame.SetActive(false);
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spawnRoutine = StartCoroutine(ObjectFall());
    }

    void Update()
    {
        if (gamestart)
        {
            if (!gameended)
            {
                timestart -= Time.deltaTime;
                timenow = timestart;
                timetext.text = "Time: " + Mathf.Round(timenow).ToString();
            }
            if (Mathf.Round(timenow) == 0)
            {
                gameended = true;
                timetext.text = "";
            }
        }
        if (gameended)
        {
            AllVar.totalgold = AllVar.totalgold + B.gatherscore;
            gatherbtn.GetComponent<Button>().interactable = false;
            nextgame.SetActive(true);
            StopCoroutine(spawnRoutine);
        }
    }
    
}
