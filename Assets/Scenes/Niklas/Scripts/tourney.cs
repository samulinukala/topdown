using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourney : MonoBehaviour
{
    public List<int> remainingPlayers = new List<int>();
    private playerHP[] playerObjs;
    void Start()
    {
        playerObjs = FindObjectsOfType<playerHP>();

        for (int i = 0; i < playerObjs.Length; i++)
        {
            remainingPlayers.Add(i);
        }
    }
    void Update()
    {
        for (int i = 0; i < playerObjs.Length; i++)
        {
            if(playerObjs[i].health <= 0)
            {
                remainingPlayers.Remove(i);
            }
        }

        if(remainingPlayers.Count == 1)
        {
            Debug.Log("Meillä on voittaja!");

            for (int i = 0; i <= playerObjs.Length; i++)
            {
                Debug.Log("Voittaja on: " + playerObjs[i].gameObject.name);
            }
        }
    }
}
