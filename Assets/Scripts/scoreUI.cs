using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreUI : MonoBehaviour
{

    public static int score = 0;
    //And you also need a variable that holds the increasing score number, let's call it display score
    public static int displayScore = 0;
    //Variable for the UI Text that will show the score
    public Text scoreui;

    // Start is called before the first frame update

    private void Start()
    {
        scoreui = GetComponent<Text>();
    }

    private void Update()
    {

        scoreui.text = score.ToString(); ;
    }

   


}
