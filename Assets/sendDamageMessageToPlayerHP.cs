using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendDamageMessageToPlayerHP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<projectile>() != null)
        {
            Destroy(collision.gameObject);
            gameObject.GetComponentInParent<playerHP>().takeDamage();
            
            
        }
    }
}
