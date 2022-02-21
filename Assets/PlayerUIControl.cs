using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIControl : MonoBehaviour
{
    [Tooltip("UI element for this player")]
    [SerializeField] GameObject hpUI;

    private RectTransform fillBar;
    private Image fillCircle;

    // Start is called before the first frame update
    void Start()
    {
        fillBar = FindDescendantWithTag("FillBar", hpUI).GetComponent<RectTransform>();
        fillCircle = FindDescendantWithTag("FillCircle", hpUI).GetComponent<Image>();
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
    public void UpdateDashCooldown(float percentage)
    {
        fillCircle.fillAmount = percentage;
    }
}
