using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float hor, ver, cHor, cVer;
    public float movespeed;
    public float rotateSpeed;
    public Vector3 move, camMoveX, camMoveY;
    public float testx, testxmax;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        move.x = hor;
        move.z = ver;
        cHor = Input.GetAxis("Mouse X");
        cVer = Input.GetAxis("Mouse Y");
        camMoveY.y = cHor;
        camMoveX.x = -cVer;
    }
    public void FixedUpdate()
    {
        
        if (Input.GetButton("Fire2"))
        {
            Vector3 newEuler = cam.transform.localEulerAngles;
            float tempClamp = newEuler.x;
            print(newEuler);
            if (newEuler.x > 180)
            {
                tempClamp -= 360;
            }
            tempClamp = Mathf.Clamp(tempClamp, testx, testxmax);
            newEuler.x = tempClamp;
            cam.transform.eulerAngles = newEuler;
            cam.transform.Rotate(camMoveX * Time.deltaTime * rotateSpeed, Space.Self);
            cam.transform.Rotate(camMoveY * Time.deltaTime * rotateSpeed, Space.World); //y world, x local
            Vector3 walkDirection = new Vector3();
            if(hor != 0)
            {
                if(hor > 0)
                {
                    walkDirection += cam.transform.right * hor;
                }
                else
                {
                    walkDirection -= cam.transform.right * -hor;
                }
            }
            if(ver != 0)
            {
                if (ver > 0)
                {
                    walkDirection += cam.transform.forward * ver;
                }
                else
                {
                    walkDirection -= cam.transform.forward * -ver;
                }
            }
            walkDirection.y = 0;
            move = walkDirection;
        }
        transform.Translate(move * Time.deltaTime * movespeed);
    }
}
