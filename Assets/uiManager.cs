using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public PlayerUIControl[] PlayerUiElements;
    public playermover[] players;

    public GameObject winScreen;
    public Text winPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<players.Length-1;i++)
        {
            
        }
    }

    public void ShowWinner(GameObject obj)
    {
        winPlayer.text = obj.name;

        winScreen.SetActive(true);
    }
}
