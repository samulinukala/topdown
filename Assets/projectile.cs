using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float moveSpeed = 50;
    public Vector2 playerLoc;
    public List<GameObject> players;

    public GameObject spawnPoint;
    // Start is called before the first frame update



    // Start is called before the first frame update
    void Start()
    {
        playerLoc = GameObject.FindObjectOfType<playermover>().gameObject.transform.position - transform.position;

        GetComponent<Rigidbody2D>().AddForce(-playerLoc.normalized * moveSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        players.Clear();
        foreach (pawn p in GameObject.FindObjectsOfType<pawn>())
        {
            players.Add(p.gameObject);
        }
        foreach (GameObject i in players)
        {
            if (GetComponent<Collider2D>().bounds.Intersects(i.GetComponent<Collider2D>().bounds))
            {
                i.GetComponentInChildren<playerHP>().health -= 1;
                i.GetComponent<pawn>().takedamage();
                Destroy(gameObject);
            }
        }
    } 
        
           
        
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}


