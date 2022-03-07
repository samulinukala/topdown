using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tourney : MonoBehaviour
{
    public List<GameObject> playerObjs = new List<GameObject>();
    public int[] playerLives;
    public GameObject[] playerPrefabs;
    

    void Update()
    {
        for (int i = 0; i < playerObjs.Count; i++)
        {
            if(playerObjs[i] == null)
            {
               
                
                playerObjs.RemoveAt(i);
                Debug.Log("pelaaja "+i + " on poissa pelistä!");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if(playerObjs.Count == 1)
        {
            Debug.Log("Meillä on voittaja!");
            
            foreach (GameObject obj in playerObjs)
            {
                Debug.Log("Voittaja on: " + obj.gameObject.name + "!");
            }
            Destroy(playerObjs[0]);
            startNewGame();
        }
    }
    public void startNewGame()
    {
        for(int i = 0; i < playerPrefabs.Length;i++)
        {
            if (playerLives[i] >= 0)
            {
                playerObjs.Add(Instantiate(playerPrefabs[i]));
               GameObject.FindObjectOfType<PlayerSpawn>().SpawnPlayer( playerObjs[i]);
                
            }
        }
        
    }
}
