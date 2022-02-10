using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermover : MonoBehaviour
{
    public float horizontal ;
    public float vertical;
    public float moveForce=5;
    public Vector2 movementVector;
    public CharacterController controller;
    public float deadZone=0.025f;
    public float contAHor;
    public float contAVer;
    public float angle;
    public float damage = 33.3333f;
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {
       
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {

        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        movementVector = new Vector2(horizontal, vertical).normalized*moveForce*Time.deltaTime;
        contAHor = Input.GetAxis("AimHorizontalController");
        contAVer = Input.GetAxis("AimVerticalController");
        Debug.Log(contAHor+" , "+ contAVer);


        if (new Vector2(contAHor, contAVer).magnitude > deadZone)
        {
            angle = Mathf.Atan2(-contAVer, -contAHor);
            transform.rotation = Quaternion.EulerAngles(0, 0, angle);

        }
       // Debug.Log("move"+movementVector);
        controller.Move(movementVector);
    }
    public void takeDamage() 
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
