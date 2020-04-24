using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TuTorialHandler : MonoBehaviour
{
    private int gamescene;
    public Text Title;
    public Text Rules;
    public static bool tutorial_online = false;
    CountDown Cd;
    CountDownGather Cdg;
    public Text middle_cd_text;
    public Text gather_game_cd_text;
    
    void Awake()
    {
        if (!tutorial_online)
        {
            TutorialDissapear();
        }
    }
    void Start()
    {
        Cd = FindObjectOfType<CountDown>();
        Cdg = FindObjectOfType<CountDownGather>();
        gamescene = SceneManager.GetActiveScene().buildIndex;
        
        if (gamescene == 1)
        {
            Title.text = "Middle Matters";
            Rules.text = "-You have five circles in middle." + "\n"
                + "-Four clouds on the edges." + "\n"
                + "-Each cloud has a different color." + "\n"
                + "-Each circle has a color." + "\n"
                + "-You will earn two points by pressing the cloud which have same color with middle circle !" + "\n"
                + "-Every time you press a cloud, everything changes !" + "\n"
                + "-If you press the wrong cloud you will lose a point :(";
        }
        else if (gamescene == 2)
        {
            Title.text = "Simon Says";
            Rules.text = "There are four different colored fruits." + "\n"
                + "-One fruit will signal you by shining. You have to press it." + "\n"
                + "-First signal is duplicated, after that  there is a new signal. You have to press them both in order." + "\n"
                + "-First and second signal is duplicated, after that  there is a new signal." + "\n"
                + "-Continue playing as long as you can repeat each sequence of signals correctly." + "\n"
                + "-If you fail to press the correct fruit, game ends :(";
        }
        else if (gamescene == 3)
        {
            Title.text = "Find Duplicates !";
            Rules.text = "There are bugs hiding under the cards !" + "\n"
                + "-Every bug has a duplicate." + "\n"
                + "-By pressing a one card, you unfold the card to see a bug." + "\n"
                + "-By pressing a second card; if they are the same, cards disappear, if not, they are folded again." + "\n"
                + "-To win the game, you have to make every card disappear." + "\n"
                + "-Good Luck !!";
        }
        else if (gamescene == 4)
        {
            Title.text = "Catch and Store !";
            Rules.text = "-Apples and peppers are falling from the sky !" + "\n"
                + "-Your job is to catch them." + "\n"
                + "-There are baskets on your right and left." + "\n"
                + "-Left is for peppers, right is for apples" + "\n"
                + "-You can catch more than one item but you can only store the item on the top." + "\n"
                + "-You can only hold six items." + "\n"
                + "-Good Luck!";
        }
        else if (gamescene == 5)
        {
            Title.text = "Rotate and Solve !";
            Rules.text = "-There is a picture divided and its pieces rotated." + "\n"
                + "-By pressing a piece, you rotate them clockwise." + "\n"
                + "-Try to rotate every piece to see the picture !";

        }

        else if (gamescene == 7)
        {
            Title.text = "Tilt Golf";
            Rules.text = "-There is ball and a hole." + "\n"
                + "-Try to send ball to hole by tilting your device." + "\n"
                + "-Careful for the obstacles." + "\n"
                + "-Good Luck !";
        }

        else if (gamescene == 6)
        {
            Title.text = "Operation: Platform";
            Rules.text = "-There are four platforms." + "\n"
                + "-Each platform holds a number." + "\n"
                + "-There are three operants represented by; cross for multiplication, plus for addition, minus for substraction." + "\n"
                + "-You have to find the answer by solving operation and press the right answer." + "\n"
                + "-Good Luck!";
         }
    }

     public void CloseTutorial()
    {
        TutorialDissapear();
        tutorial_online = false;
        if (gamescene == 1)
        {
            Cd.countdownTime = 4;
            middle_cd_text.text = Cd.countdownTime.ToString();
        }
        else if (gamescene == 4)
        {
            Cdg.countdownTime = 4;
            gather_game_cd_text.text = Cdg.countdownTime.ToString();
        }
    }

    public void TutorialDissapear()
    {
        this.GetComponentInChildren<CanvasGroup>().alpha = 0;
        this.GetComponentInChildren<CanvasGroup>().interactable = false;
        this.GetComponentInChildren<CanvasGroup>().blocksRaycasts = false;
    }
    
    void Update()
    {
        
    }
}
