using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIControl : MonoBehaviour
{
    [Tooltip("UI element for this player")]
    [SerializeField] GameObject hpUI;
   
    private int playerNum;
    private RectTransform fillBar;
    

    // Start is called before the first frame update
    void Start()
    {
        fillBar = FindDescendantWithTag("FillBar", hpUI).GetComponent<RectTransform>();
        playerNum = gameObject.GetComponent<playermover>().playerNum;
    }
   public void updateHealthBar()
    {
        if (GameObject.FindObjectOfType<tourney>().playerLives[playerNum - 1] == 3) UpdateHealthBar(1);
        if (GameObject.FindObjectOfType<tourney>().playerLives[playerNum - 1] == 2) UpdateHealthBar(0.66666f);
        if (GameObject.FindObjectOfType<tourney>().playerLives[playerNum - 1] == 1) UpdateHealthBar(0.3333333f);
        if (GameObject.FindObjectOfType<tourney>().playerLives[playerNum - 1] == 0) UpdateHealthBar(0);
    }

    // Recursive search for the GameObject with the given tag
    private GameObject FindDescendantWithTag(string tag, GameObject parent)
    {
        GameObject result = null;

        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.CompareTag(tag))
            {
                return child.gameObject;
            }
            result = FindDescendantWithTag(tag, child.gameObject);
        }
        return result;
    }

    // Parameter should be between 0 - 1
    public void UpdateHealthBar(float percentage)
    {
        fillBar.localScale = new Vector3(percentage, 1, 1);
    }

    // Parameter should be between 0 - 1
   
}
