using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn : MonoBehaviour
{

    int health = 4;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    public void takedamage()
    {
        Debug.Log("damage To pawn");
        
            health -= 1;
            if (health < 1)
            {
                Destroy(gameObject);
            }
        
    }
}
