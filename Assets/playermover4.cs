using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermover4 : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveForce = 5;
    public Vector2 movementVector;
    public CharacterController controller;
    public float deadZone = 0.025f;
    public float contAHor;
    public float contAVer;
    public float angle;
    public float damage = 33.3333f;
    public float health = 100;
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

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleFire();

    }
    public void takeDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void handleMovement()
    {
        vertical = Input.GetAxisRaw("Vertical4");
        horizontal = Input.GetAxisRaw("Horizontal4");
        movementVector = new Vector2(horizontal, vertical).normalized * moveForce * Time.deltaTime;
        contAHor = Input.GetAxis("AimHorizontalController4");
        contAVer = Input.GetAxis("AimVerticalController4");
        Debug.Log(contAHor + " , " + contAVer);
        if (dashcalc < dashlenght & isDashing == true)
        {
            dashcalc += 1 * Time.deltaTime;
            controller.Move(movementVector.normalized * dashForce);
        }
        else if (dashcalc > dashlenght & isDashing == true)
        {
            dashcalc = 0;
            isDashing = false;
        }

        if (new Vector2(contAHor, contAVer).magnitude > deadZone)
        {
            angle = Mathf.Atan2(-contAVer, -contAHor);
            transform.rotation = Quaternion.EulerAngles(0, 0, angle);

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

            controller.Move(movementVector);
        }


    }
    public void handleFire()
    {
        if (Input.GetAxis("fireC4") > 0 & canFire == true)
        {
            canFire = false;
            Debug.Log("fire");
            Instantiate(projectile, gunBarrel.transform.position, transform.rotation);
        }
        else
        {
            if (fireCooldown > fireCalc)
            {
                fireCalc = fireCalc + 1 * Time.deltaTime;
            }
            else if (fireCooldown < fireCalc)
            {
                fireCalc = 0;
                canFire = true;
            }
        }
    }

}
