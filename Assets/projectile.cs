using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float moveSpeed = 50;
    public Vector2 playerLoc;
    public GameObject playerWhoShot;

    public GameObject spawnPoint;
    public float lifetime=5f;
    // Start is called before the first frame update
 

    // Start is called before the first frame update
    void Start()
    {
        playerWhoShot = GetComponentInParent<playermover>().gameObject;
   
        playerLoc = playerWhoShot.transform.position - transform.position;
        transform.parent = null;

        GetComponent<Rigidbody>().AddForce(-playerLoc.normalized * moveSpeed, ForceMode.Impulse);
       
    }

    // Update is called once per frame


    private void Update()
    {
<<<<<<< HEAD
        
=======
        if (collision.gameObject.GetComponent<projectile>() == null && collision.gameObject.GetComponent<playermover>() == null)
        {
            Destroy(gameObject);
        }
       
>>>>>>> parent of 47c4324 (fixed no damage)
    }



    //   if (!collision.gameObject.CompareTag("projectile"))
    //  {


    //        if (collision.gameObject.CompareTag("wall") == true && collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("projectile"))
    //        {
    //            Debug.Log("fgfdg");
    //        }

    //    }
    //}
}


