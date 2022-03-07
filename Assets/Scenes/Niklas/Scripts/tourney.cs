using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tourney : MonoBehaviour
{
    public List<GameObject> playerObjs = new List<GameObject>();
    public int[] playerLives;
    public List<GameObject> deadPlayers;
    

    void Update()
    {
      


        {
            Debug.Log("Meillä on voittaja!");

            foreach (GameObject obj in playerObjs)
            {
                Debug.Log("Voittaja on: " + obj.gameObject.name + "!");
            }

           
            
            for (int i = 0; i < playerObjs.Count; i++)
            {

                if (playerObjs[i].activeInHierarchy == false)
                {
                   
                }

                Debug.Log("pelaaja " + i + " on poissa pelistä!");

            }
            startNewGame();
        }
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
    
    public void startNewGame()
    {
        for(int i = 0; i < playerLives.Length;i++)
        {
            if (playerLives[i] > 0)
            {
                if (playerObjs[i].activeInHierarchy==false)
                {



                    playerObjs[i].SetActive(true);
                    playerObjs[i].GetComponent<playermover>().resetPlayer();
                    GameObject.FindObjectOfType<PlayerSpawn>().SpawnPlayer(playerObjs[i]);

                    
                }
            }
        }
        
        
    }
}
