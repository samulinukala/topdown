using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourney : MonoBehaviour
{
    public List<playerHP> playerObjs = new List<playerHP>();

    void Update()
    {
        for (int i = 0; i < playerObjs.Count; i++)
        {
            if(playerObjs[i].health <= 0)
            {
                Debug.Log(playerObjs[i].gameObject.name + " on poissa pelistä!");
                playerObjs.RemoveAt(i);
            }
        }

        if(playerObjs.Count == 1)
        {
            Debug.Log("Meillä on voittaja!");
            foreach (playerHP obj in playerObjs)
            {
                Debug.Log("Voittaja on: " + obj.gameObject.name + "!");
            }
        }
    }
}
