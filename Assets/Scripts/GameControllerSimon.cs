using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSimon : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameSession gameSes;
    public int buttonNumber;
    private Vector2 zero;
    private AudioSource theSound;
    


    // Start is called before the first frame update
    void Start()
    {
       
        sprite = GetComponent<SpriteRenderer>();
        gameSes = FindObjectOfType<GameSession>();
        theSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameSes.stop)
        {
            zero.x = 0;
            zero.y = 0;
            GetComponent<BoxCollider2D>().size = zero; //In order to keep buttons not pressable
        }
       
    }

    void OnMouseDown()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        theSound.Play();
    }
    private void OnMouseUp()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
        gameSes.ColourPressed(buttonNumber);
        theSound.Stop();
    }
}
