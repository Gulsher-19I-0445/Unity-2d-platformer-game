using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamplaySounds : MonoBehaviour


{
    public static AudioClip playerhit, playerJump, itemcollection,enemykilled;

    static AudioSource audioSrc;



    // Start is called before the first frame update
    void Start()
    {
        playerhit = Resources.Load<AudioClip>("FeedBack");
        playerJump = Resources.Load<AudioClip>("PlayerJump");
        enemykilled = Resources.Load<AudioClip>("enemyDeath");
        audioSrc = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        if (clip == "PlayerHit")
        {
            audioSrc.PlayOneShot(playerhit);
        }
        if (clip == "Jumped")
        {
            audioSrc.PlayOneShot(playerJump);
        }
        if (clip == "Edead")
        {
            audioSrc.PlayOneShot(enemykilled);
        }


    }
}
