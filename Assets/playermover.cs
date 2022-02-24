using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermover :MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveForce = 5;
    public Vector2 movementVector;
   
    public float deadZone = 0.025f;
    public float contAHor;
    public float contAVer;
    public float angle;
    public int health = 4;
    public GameObject projectile;
    public float fireCooldown = 0.5f;
    public float fireCalc = 0;
    public bool canFire = true;
    public float movementDeadZone = 0.4f;
    public GameObject gunBarrel;
    public float dashForce = 2;
    public float dashlenght = 0.5f;
    public float dashcalc = 0;
    public bool isDashing = false;
    public float dashCooldown = 2.5f;
    public float dashCooldownCalc = 0;
    public bool dashInCoolDown = false;
    public GameObject tmp;
    public int playerNum = 1;
    
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    

    }
    public void takedamage()
    {
        Debug.Log("damage To pawn");

        health -= 1;
        if (health < 1)
        {
            Destroy(gameObject);
        }

    }

    public void handleMovement()
    {
        vertical = Input.GetAxisRaw("Vertical" + playerNum);
        horizontal = Input.GetAxisRaw("Horizontal" + playerNum);
        movementVector = new Vector2(horizontal, vertical).normalized * moveForce * Time.deltaTime;

     

        if (dashcalc < dashlenght & isDashing == true)
        {
            dashcalc += 1 * Time.deltaTime;
          
            transform.Translate(movementVector*dashForce);
        }
        else if (dashcalc > dashlenght & isDashing == true)
        {
            dashcalc = 0;
            isDashing = false;
        }

        if (dashInCoolDown == true)
        {
            if (dashCooldown > dashCooldownCalc)
            {
                dashCooldownCalc += 1 * Time.deltaTime;

            }
            else if (dashCooldown < dashCooldownCalc)
            {
                dashCooldownCalc = 0;
                dashInCoolDown = false;
            }
        }
        if (playerNum == 1)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) & dashInCoolDown == false)
            {
                //  dashLocation = dashMarker.transform.position-transform.position;
                Debug.Log("dash");
                isDashing = true;
                dashInCoolDown = true;
            }
            else
           // Debug.Log("move"+movementVector);
           if (new Vector2(horizontal, vertical).magnitude > movementDeadZone)
            {

                transform.Translate(movementVector);
            }
        }
        if (playerNum == 2)
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button0) & dashInCoolDown == false)
            {
                //  dashLocation = dashMarker.transform.position-transform.position;
                Debug.Log("dash");
                isDashing = true;
                dashInCoolDown = true;
            }
            else
           // Debug.Log("move"+movementVector);
           if (new Vector2(horizontal, vertical).magnitude > movementDeadZone)
            {

                transform.Translate(movementVector);
            }
        }
        if (playerNum == 3)
        {
            if (Input.GetKeyDown(KeyCode.Joystick3Button0) & dashInCoolDown == false)
            {
                //  dashLocation = dashMarker.transform.position-transform.position;
                Debug.Log("dash");
                isDashing = true;
                dashInCoolDown = true;
            }
            else
           // Debug.Log("move"+movementVector);
           if (new Vector2(horizontal, vertical).magnitude > movementDeadZone)
            {

                transform.Translate(movementVector);
            }
        }
        if (playerNum == 4)
        {
            if (Input.GetKeyDown(KeyCode.Joystick4Button0) & dashInCoolDown == false)
            {
                //  dashLocation = dashMarker.transform.position-transform.position;
                Debug.Log("dash");
                isDashing = true;
                dashInCoolDown = true;
            }
            else
           // Debug.Log("move"+movementVector);
           if (new Vector2(horizontal, vertical).magnitude > movementDeadZone)
            {

                transform.Translate(movementVector);
            }
        }


    }
}
