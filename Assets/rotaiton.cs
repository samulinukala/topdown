using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotaiton : MonoBehaviour
{
     playermover playermover;
    // Start is called before the first frame update
    void Start()
    {
        playermover = GetComponentInParent<playermover>();
    }
    public void handleFire()
    {
        if (Input.GetAxis("fireC" + playermover.playerNum) > 0 & playermover.canFire == true)
        {
            playermover.fireCalc = 0;
            playermover.canFire = false;
            Debug.Log("fire");
            playermover.tmp = Instantiate(playermover.projectile, playermover.gunBarrel.transform.position, transform.rotation);
            playermover.tmp.transform.parent = gameObject.transform;
        }
        else
        {
            if (playermover.fireCooldown > playermover.fireCalc)
            {
                playermover.fireCalc = playermover.fireCalc + 1 * Time.deltaTime;
            }
            else if (playermover.fireCooldown < playermover.fireCalc)
            {
               
                playermover.canFire = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleFire();
        playermover.contAHor = Input.GetAxis("AimHorizontalController" + playermover.playerNum);
        playermover.contAVer = Input.GetAxis("AimVerticalController" + playermover.playerNum);

        if (new Vector2(playermover.contAHor, playermover.contAVer).magnitude > playermover.deadZone)
        {
            playermover.angle = Mathf.Atan2(-playermover.contAVer, -playermover.contAHor);
            transform.rotation = Quaternion.EulerAngles(0, 0, playermover.angle);

        }

    }
}
