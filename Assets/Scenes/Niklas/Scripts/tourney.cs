using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class tourney : MonoBehaviour
{
    public List<GameObject> playerObjs = new List<GameObject>();
    public int[] playerLives;
    public List<GameObject> deadPlayers;
    public List<GameObject> playersInSpawn;
    public List<int> playerScores;
    public Image leader;
    public Color[] playerColors;
    public bool gameOver = false;
    public List<leaderBoardValue> leaderBoardValues;
    public float gameTimer=120;
    public float doNothingTimer=3f;
    public Canvas winScreen;
    public bool DoOnce=false;
    public Text timeLeft;
    public List<GameObject> playersOutOfLives;
    public Text[] playerScoreTexts;
    public Image[] leaderPostions;
    public int Currleader;
   public List<leaderBoardValue> sortedList;
    public void Start()
    {
        leaderBoardValues.Add(new leaderBoardValue(0,0));
        leaderBoardValues.Add(new leaderBoardValue(0, 1));
        leaderBoardValues.Add(new leaderBoardValue(0, 2));
        leaderBoardValues.Add(new leaderBoardValue(0, 3));

    }
    public void updateWinScreen()
    {
        for (int i = 0; i < 11; i++) {
            foreach (leaderBoardValue l in leaderBoardValues)
            {
                foreach (leaderBoardValue lb in leaderBoardValues)
                {
                    if (l != lb)
                    {
                        if (l.score > lb.score)
                        {
                            l.placeInTheLeaderBoard -= 1;
                            lb.placeInTheLeaderBoard += 1;
                        }
                    }
                }
            }
           
        }
        sortedList = leaderBoardValues.OrderBy(x => x.placeInTheLeaderBoard).ToList();
        for (int i = 0; i < leaderBoardValues.Count; i++)
        {
            leaderPostions[i].color = playerColors[i];
            playerScoreTexts[i].text = "Score: " + sortedList[i].score.ToString();
        }

    }
    void Update()
    {
        if (gameOver == true)
        {
            if (DoOnce == false)
            {
                DoOnce = true;
                updateWinScreen();
            }
            winScreen.enabled = true;
            if (doNothingTimer > 0)
            {
                doNothingTimer -= 1 * Time.deltaTime;
            }
            if (doNothingTimer < 0)
            {
                if(Input.GetKeyDown(KeyCode.Joystick4Button1)|| Input.GetKeyDown(KeyCode.Joystick3Button1)|| Input.GetKeyDown(KeyCode.Joystick2Button1)|| Input.GetKeyDown(KeyCode.Joystick1Button1))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
       
        if (playersOutOfLives.Count == 3||gameTimer<0)
        {
            gameOver = true;
        }
        if (gameOver == false)
        {
            for(int i=0;i<playerObjs.Count;i++)
            {
                if (!playersOutOfLives.Contains(playerObjs[i]))
                {
                    if (playerLives[i] <= 0)
                    {
                        playersOutOfLives.Add(playerObjs[i]);
                    }
                }
            }
            timeLeft.text ="Time left: "+((float)((int)gameTimer)).ToString();
            gameTimer -= 1 * Time.deltaTime;
            if (playerScores[0] > playerScores[1] & playerScores[0] > playerScores[2] & playerScores[0] > playerScores[3])
            {
                leader.color = playerColors[0];
                Currleader = 0;
            }
            if (playerScores[1] > playerScores[0] & playerScores[1] > playerScores[2] & playerScores[1] > playerScores[3])
            {
                leader.color = playerColors[1];
                Currleader = 1;
            }
            if (playerScores[2] > playerScores[1] & playerScores[2] > playerScores[0] & playerScores[2] > playerScores[3])
            {
                leader.color = playerColors[2];
                Currleader = 2;
            }
            if (playerScores[3] > playerScores[1] & playerScores[3] > playerScores[2] & playerScores[3] > playerScores[0])
            {
                leader.color = playerColors[3];
                Currleader = 3;
            }






            PlayerSpawning();

            for (int i = 0; i < playerLives.Length; i++)
            {
                if (playerLives[i] == 0)
                {
                    if (deadPlayers.Contains(playerObjs[i]))
                    {
                        deadPlayers.Add(playerObjs[i]);
                    }
                }



            }
        }
    }
    public void addScoreToPlayer(GameObject player)
    {
        for(int i = 0; i < playerScores.Count; i++)
        {
            if (playerObjs[i] == player)
            {
                playerScores[i] += 1;
                leaderBoardValues[i].score += 1;

            }
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
[System.Serializable]
public class leaderBoardValue
{
    public int score;
    public int playerNum;
    public int placeInTheLeaderBoard=1;
   public leaderBoardValue(int _score,int _playerNum)
    {
        score = _score;
        playerNum = _playerNum;

    }
}
