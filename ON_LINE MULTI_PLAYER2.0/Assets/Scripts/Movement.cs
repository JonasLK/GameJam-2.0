using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float hor, ver, cHor, cVer;
    public float movespeed;
    public float rotateSpeed, bodyRotateSpeed;
    public float walkingSpeed, runningSpeed;
    public Vector3 move, camMoveX, camMoveY;
    public float testx, testxmax;
    public float maxZoom, minZoom;
    public bool walking, running, moving;
    public GameObject cam;
    public GameObject actualCam;
    public Transform actualBodyModel;
    public Vector3 walkDirection = new Vector3();

    public void Awake()
    {
        movespeed = walkingSpeed;
        Cursor.lockState = CursorLockMode.Locked;
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
        walkDirection = Vector3.zero;
        if(hor != 0|| ver != 0)
        {
            
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
                walking = true;
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
                walking = true;
            }
        }
        else
        {
            walking = false;
            running = false;
            moving = false;
        }
        if (Input.GetButton("Run"))
        {
            running = true;
            walking = false;
            movespeed = runningSpeed;
        }
        else
        {
            running = false;
            movespeed = walkingSpeed;
        }
        if(walking || running)
        {
            moving = true;
        }
        walkDirection.y = 0;
        move = walkDirection;
        float cameraDis = Vector3.Distance(actualCam.transform.position, cam.transform.position);
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && cameraDis >= minZoom)
        {
            actualCam.transform.position += actualCam.transform.forward;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0 && cameraDis <= maxZoom)
        {
            actualCam.transform.position -= actualCam.transform.forward;
        }
    }
    public void FixedUpdate()
    {
        
        if (Input.GetButton("Fire2"))
        {
            Vector3 newEuler = cam.transform.localEulerAngles;
            float tempClamp = newEuler.x;
            if (newEuler.x > 180)
            {
                tempClamp -= 360;
            }
            tempClamp = Mathf.Clamp(tempClamp, testx, testxmax);
            newEuler.x = tempClamp;
            cam.transform.eulerAngles = newEuler;
            cam.transform.Rotate(camMoveX * Time.deltaTime * rotateSpeed, Space.Self);
            //gameObject.transform.Rotate(camMoveY * Time.deltaTime * rotateSpeed);
            cam.transform.Rotate(camMoveY * Time.deltaTime * rotateSpeed, Space.World); //y world, x local
        }
        Quaternion rotationWeWnat = Quaternion.LookRotation(walkDirection);
        actualBodyModel.transform.rotation = Quaternion.RotateTowards(actualBodyModel.transform.rotation, rotationWeWnat, bodyRotateSpeed);
        transform.Translate(move * Time.deltaTime * movespeed);
    }
}
