using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float moveSpeed=50;
    public Vector2 playerLoc;
<<<<<<< HEAD:New Unity Project (4)/Assets/projectile.cs
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerLoc = spawnPoint.transform.position
=======
    // Start is called before the first frame update
    void Start()
    {
        playerLoc = GameObject.FindObjectOfType<playermover>().gameObject.transform.position-transform.position;
>>>>>>> b8c3b8b2514b5b69e517e96060b729cc96bc6862:Assets/projectile.cs
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
