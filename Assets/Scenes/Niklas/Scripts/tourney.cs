using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tourney : MonoBehaviour
{
    public List<GameObject> playerObjs = new List<GameObject>();
    public int[] playerLives;
    public List<GameObject> deadPlayers;
    public List<GameObject> playersInSpawn;

    void Update()
    {







        PlayerSpawning();
        
        for( int i =0;i<playerLives.Length;i++)
        {
            if (playerLives[i] == 0)
            {
                if (deadPlayers.Contains(playerObjs[i])) {
                    deadPlayers.Add(playerObjs[i]);
            } }
            

            
        }
        if (deadPlayers.Count > 3)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    public void PlayerSpawning()
    {
        for(int i = 0; i < playerLives.Length;i++)
        {
            if (playerLives[i] > 0)
            {
                if (playerObjs[i].activeInHierarchy==false&&!playersInSpawn.Contains(playerObjs[i]))
                {


                    playersInSpawn.Add(playerObjs[i]);
                    GameObject.FindObjectOfType<PlayerSpawn>().SpawnPlayer(playerObjs[i]);

                    playerObjs[i].GetComponent<playermover>().resetPlayer();
                    


                }
            }
        }
        
        
    }
}
