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
        for (int i = 0; i < playerObjs.Count; i++)
        {

            if (playerObjs[i].activeInHierarchy == false)
            {
                deadPlayers.Add(playerObjs[i]);
            }
                
             
                Debug.Log("pelaaja "+i + " on poissa pelistä!");
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }


        {
            Debug.Log("Meillä on voittaja!");

            foreach (GameObject obj in playerObjs)
            {
                Debug.Log("Voittaja on: " + obj.gameObject.name + "!");
            }
            if (deadPlayers.Count > 2)
            {
                startNewGame();
            }
        }
    }
    public void startNewGame()
    {
        for(int i = 0; i < deadPlayers.Count;i++)
        {
            if (playerLives[i] > 0)
            {
                playerObjs[i].GetComponent<playermover>().resetPlayer();
                playerObjs[i].SetActive( true);
                playerObjs[i].GetComponent<playermover>().resetPlayer();
                GameObject.FindObjectOfType<PlayerSpawn>().SpawnPlayer( playerObjs[i]);
                
                playerLives[i] = 3;
            }
        }
        deadPlayers.Clear();
        
    }
}
