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
    void Start()
    {        
        playerWhoShot = GetComponentInParent<playermover>().gameObject;
   
        playerLoc = playerWhoShot.transform.position - transform.position;
        transform.parent = null;

        GetComponent<Rigidbody2D>().AddForce(-playerLoc.normalized * moveSpeed, ForceMode2D.Impulse);
       
    }

    //Checks wall collision and destroys projectiles
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall")==true&&collision.gameObject.GetComponent<CharacterController>()==null)
        {
            Destroy(gameObject);
        }
       
    }
}


