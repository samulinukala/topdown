using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float moveSpeed=50;
    public Vector2 playerLoc;
    // Start is called before the first frame update
    void Start()
    {
        playerLoc = GameObject.FindObjectOfType<playermover>().gameObject.transform.position-transform.position;
        GetComponent<Rigidbody2D>().AddForce(playerLoc.normalized*moveSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<playermover>()!=null)
        {
            collision.GetComponent<playermover>().takeDamage();
            Destroy(gameObject);
        }
    }
}
