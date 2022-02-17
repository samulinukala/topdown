using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourney : MonoBehaviour
{
    public List<int> remainingPlayers = new List<int>();
    private playerHP[] playerObjs;
    private playerHP[] winner;
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
        winner = FindObjectsOfType<playerHP>();

        for (int i = 0; i < winner.Length; i++)
        {
            if(winner[i].health <= 0)
            {
                remainingPlayers.Remove(i);
                Debug.Log(winner[i].gameObject.name + " on poissa pelistä!");
            }
        }

        if(remainingPlayers.Count == 1)
        {
            Debug.Log("Meillä on voittaja!");
            foreach (playerHP obj in winner)
            {
                Debug.Log("Voittaja on: " + obj.gameObject.name + "!");
            }
        }
    }
}
