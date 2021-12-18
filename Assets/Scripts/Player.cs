using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //-------------------------------
    [SerializeField]

    private float moveforce = 5f;
    [SerializeField]
    private float jumpForce = 7f;
    private float movementx;

    private SpriteRenderer sr;//to flip our character accordingly

    private Animator anim;                      //to control player animation
    private string WALK_ANIMATION = "run";
    private string JUMP_ANIMATION = "jump";
    

    //Combad variables
    private string Enemy_tag = "Enemy";
    private string Dmg_tag = "dmg";
    private Rigidbody2D mybody;
    public int health=3;
    public float invinciblityFrames = 2;
    int enemylayer;
    int playerlayer;

    [SerializeField]
    private float jumpForceFeedback = 4f;

    private bool isGrounded = false;
    private string Ground_tag="Ground";

    //-------------------------------
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();    //initialize object of sprite renderer
        mybody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        animatePlayer();
        playerJump();
    }

    void PlayerMove()
    {
        movementx = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementx, 0f, 0f) * Time.deltaTime * moveforce;


    }

    void animatePlayer()
    {
        if (movementx > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementx < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

        if (isGrounded == false)
        {
            anim.SetBool(JUMP_ANIMATION, true);
        }
        else
        {
            anim.SetBool(JUMP_ANIMATION, false);
        }



    }


    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GamplaySounds.PlaySound("Jumped");
            isGrounded = false;
            anim.SetBool(JUMP_ANIMATION, true);
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
            // OnCollisionEnter2D(mybody);
        }
        else
        {
           // anim.SetBool(JUMP_ANIMATION, false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)          
    {
        Enemy enemy=collision.collider.GetComponent<Enemy>();
        CollectiblesController myItem = collision.collider.GetComponent<CollectiblesController>();
        if (collision.gameObject.CompareTag(Ground_tag))
        {
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);
        }

        if (enemy != null)
        {
            foreach(ContactPoint2D point in collision.contacts)
            {
                Debug.DrawLine(point.point, point.point + point.normal,Color.black,10);
                if (point.normal.y >= 0.9f)             //For Enemy death
                {
                    //enemy.Enemy_anim.SetBool("dead", true);
                    enemy.killedEnemy();
                    mybody.AddForce(new Vector2(0f, jumpForceFeedback), ForceMode2D.Impulse);
                    //anim.SetBool(Ground_tag, true);
                }
                else
                {
                    takeHit();
                }
            }
        }

        //For collection

        if (myItem != null)
        {
            if (myItem.tag == "Gem")
            {
                myItem.myItemCollected();
            }

            if (myItem.tag == "Cherry")
            {
                myItem.myCherryCollected();
                //GameplayUI.ScoreUpdater();
                scoreUI.score++;
            }


        }


    
    
}

/*private void OnTriggerEnter2D(Collider2D collision)
    
    {
        if (collision.CompareTag(Enemy_tag))
        {
            Destroy(collision.gameObject);
            isGrounded = true;
        }

    }*/




    /// 
    /// /////////
    /// 

    public void takeHit()
    {
        // anim.SetBool(Dmg_tag, true);
        health--;
        healthUI.health--;

        StartCoroutine(HurtAnim());
        if (health <= 0)
        {
            Physics2D.IgnoreLayerCollision(enemylayer, playerlayer, false);
            healthUI.health=3;
            scoreUI.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Debug.Log("HIT\n");
    }

    IEnumerator HurtAnim()
    {
        GamplaySounds.PlaySound("PlayerHit");
        enemylayer = LayerMask.NameToLayer("Enemy");
        playerlayer = LayerMask.NameToLayer("Player");
        Debug.Log("hello");
        Physics2D.IgnoreLayerCollision(enemylayer, playerlayer);
        anim.SetBool(Dmg_tag, true);
        mybody.AddForce(new Vector2(-6f, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(enemylayer, playerlayer,false);
        anim.SetBool(Dmg_tag, false);
    }

}
