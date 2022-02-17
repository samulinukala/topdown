using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float moveSpeed = 50;
    public Vector2 playerLoc;
    public GameObject playerWhoShot;

    public GameObject spawnPoint;

    // Start is called before the first frame update
 

    // Start is called before the first frame update
    void Start()
    {
        playerWhoShot = GetComponentInParent<pawn>().gameObject;
   
        playerLoc = playerWhoShot.transform.position - transform.position;
        transform.parent = null;

        GetComponent<Rigidbody2D>().AddForce(-playerLoc.normalized * moveSpeed, ForceMode2D.Impulse);
       
    }

    // Update is called once per frame
    

    
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}


