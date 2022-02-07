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
    public Vector3 aimVector;
    public float contAHor;
    public float contAVer;
    public float angle;
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
        //aimVector = new Vector3(contAHor, contAVer,0).normalized;
        angle = Mathf.Atan2(contAVer, contAHor) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.EulerAngles(0, 0, angle);
        Debug.Log("aim"+aimVector);
        Debug.Log("move"+movementVector);
        controller.Move(movementVector);
    }
}
