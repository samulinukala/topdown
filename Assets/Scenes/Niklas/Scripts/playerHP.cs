using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject fullHPSprite;
    public GameObject hp3Sprite;
    public GameObject hp2Sprite;
    public GameObject hp1Sprite;

    public bool invulnerable;
    public float damageDelay;
    public float deathDelay;
    public GameObject hitParticle;

    public Component[] colliders;
    public Component[] spriteRenderers;
    public Color invincibleColor;
    public Color regularColor;

    void Start()
    {
        colliders = GetComponentsInChildren<BoxCollider2D>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        health = maxHealth;
        fullHPSprite.SetActive(true);
        hp3Sprite.SetActive(false);
        hp2Sprite.SetActive(false);
        hp1Sprite.SetActive(false);
        invulnerable = false;
    }

    void Update()
    {
        if(health >= maxHealth)
        {
            health = maxHealth;
            fullHPSprite.SetActive(true);
            hp3Sprite.SetActive(false);
            hp2Sprite.SetActive(false);
            hp1Sprite.SetActive(false);
        }
        if (health == 3)
        {
            fullHPSprite.SetActive(false);
            hp3Sprite.SetActive(true);
            hp2Sprite.SetActive(false);
            hp1Sprite.SetActive(false);
        }
        if (health == 2)
        {
            fullHPSprite.SetActive(false);
            hp3Sprite.SetActive(false);
            hp2Sprite.SetActive(true);
            hp1Sprite.SetActive(false);
        }
        if (health == 1)
        {
            fullHPSprite.SetActive(false);
            hp3Sprite.SetActive(false);
            hp2Sprite.SetActive(false);
            hp1Sprite.SetActive(true);
        }
        if (health <= 0)
        {
            health = 0;
            StartCoroutine(deathDelayCo());

            foreach (BoxCollider2D boxObj in colliders)
            {
                boxObj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (invulnerable)
        {
            foreach (SpriteRenderer obj in spriteRenderers)
            {
                obj.GetComponent<SpriteRenderer>().color = invincibleColor;
            }
            foreach (BoxCollider2D boxObj in colliders)
            {
                boxObj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (!invulnerable)
        {
            foreach (SpriteRenderer obj in spriteRenderers)
            {
                obj.GetComponent<SpriteRenderer>().color = regularColor;
            }
            foreach (BoxCollider2D boxObj in colliders)
            {
                boxObj.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

public void takeDamage()
    {
        if(!invulnerable)
        {
            gameObject.GetComponentInParent<playermover>().takedamage();
            StartCoroutine(damageDelayCo());
           
        }
    }

    public IEnumerator damageDelayCo()
    {
        invulnerable = true;
        Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
        health -= 1;
        yield return new WaitForSeconds(damageDelay);
        invulnerable = false;
    }

    public IEnumerator deathDelayCo()
    {
        Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }
}
