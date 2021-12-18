using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D myenemy;
    private string JUMP_ANIMATION = "jump";
    public Animator Enemy_anim;
    int count = 0;
    private float x = -20;
    private float y = 2.384096f;
    // Start is called before the first frame update
    void Start()
    {
        myenemy = GetComponent<Rigidbody2D>();
        Enemy_anim = GetComponent<Animator>();
        Enemy_anim.SetBool("idle", true);
        StartCoroutine(JumpAnim());
       
       // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "damageArea" && other.tag == "Player")
        {
            other.GetComponent<Player>().takeHit();
        }

      //  else if (colliderName == "head" && other.tag == "Player")
       // {

        //    Destroy(gameObject);
        //}



    }

    IEnumerator dead()
    {

        int enemylayer = LayerMask.NameToLayer("Enemy");
        int playerlayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemylayer, playerlayer, true);
        GamplaySounds.PlaySound("Edead");
        Enemy_anim.SetBool(JUMP_ANIMATION, false);
        Enemy_anim.SetBool("idle", false);

        Enemy_anim.SetBool("dead", true);
        yield return new WaitForSecondsRealtime(1);
        Destroy(this.gameObject);
        Physics2D.IgnoreLayerCollision(enemylayer, playerlayer, false);
    }

    public void killedEnemy()
    {

        StartCoroutine(dead());
        // new WaitForSeconds(4);
        Enemy_anim.SetBool("dead", true);
        //Destroy(this.gameObject);

    }

    IEnumerator JumpAnim()
    {
        
        
        while (true)
        {

            Enemy_anim.SetBool(JUMP_ANIMATION, false);
            yield return new WaitForSeconds(2);
            Enemy_anim.SetBool(JUMP_ANIMATION, true);
            //transform.position += new Vector3(-10, 0f, 0f) * Time.deltaTime * 2;
            
            yield return new WaitForSeconds(1);
           // if (x < 6)
            //{
                transform.position += new Vector3(x, 0f, 0f) * Time.deltaTime;
            
            //transform.position += new Vector3(x, 1f, 0f) * Time.deltaTime * 2;
            count++;
            
            if (count > 4)
            {
                x *=(-1);
                y *=(-1);
                transform.localScale = new Vector3(y, 2.566543f, 1f);
                count = 0;
            }
            //}

            //else if(x>)
        }
        


    }

}
