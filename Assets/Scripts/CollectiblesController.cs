using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesController : MonoBehaviour


{
   private Rigidbody2D myCollectible;



    // Start is called before the first frame update
    void Start()
    {
        myCollectible = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void myItemCollected()
    {
        Destroy(this.gameObject);
    }
    
    public void myCherryCollected()
    {
        Destroy(this.gameObject);
        //this.transform.position += new Vector3(100, 0f, 0f) * Time.deltaTime ;
    }

}
