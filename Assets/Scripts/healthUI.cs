using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    public static int health = 3;
    //And you also need a variable that holds the increasing score number, let's call it display score
    //public static int displayScore = 0;
    //Variable for the UI Text that will show the score
    public Text healthui;

    // Start is called before the first frame update

    private void Start()
    {
        healthui = GetComponent<Text>();
    }

    private void Update()
    {

        healthui.text = health.ToString(); ;
    }
}
