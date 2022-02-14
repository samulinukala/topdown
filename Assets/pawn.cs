using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn : MonoBehaviour
{
    int health = 3;
    // Start is called before the first frame update
    public void takedamage()
    {

        health -= 1;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
