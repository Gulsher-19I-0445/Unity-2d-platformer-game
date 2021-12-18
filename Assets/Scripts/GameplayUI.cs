using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{

    //public static int score =0;
    //And you also need a variable that holds the increasing score number, let's call it display score
    //public static int displayScore=0;
    //Variable for the UI Text that will show the score
    //public static Text scoreUI;
    
    // Start is called before the first frame update
    public void restart()
    {
        healthUI.health = 3;
        scoreUI.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void home()
    {
        SceneManager.LoadScene("MainMenu");
    }





}
