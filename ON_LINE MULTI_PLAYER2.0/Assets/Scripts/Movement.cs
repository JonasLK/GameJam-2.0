﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float interactionRange;
    public LayerMask interactableLayers;
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

    public GameObject interactIndicator;

    public void Awake()
    {
        movespeed = walkingSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Interaction();
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
        }
        else
        {
            walking = false;
            running = false;
            moving = false;
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
    public void Interaction()
    {
        Collider[] interactables = Physics.OverlapSphere(transform.position, interactionRange, interactableLayers);
        if(interactables.Length > 0)
        {
            GameObject selectedInteractable = interactables[0].gameObject;
            foreach(Collider interactable in interactables)
            {
                if(Vector3.Distance(selectedInteractable.transform.position, transform.position) > Vector3.Distance(interactable.transform.position, transform.position))
                {
                    selectedInteractable = interactable.gameObject;
                }
            }
            interactIndicator.SetActive(true);
            interactIndicator.GetComponentInChildren<Text>().text = selectedInteractable.GetComponent<Buyable>().cost.ToString();
            if (Input.GetButtonDown("Interact"))
            {
                selectedInteractable.GetComponent<Interactable>().Interact();
            }
        }
        else
        {
            interactIndicator.SetActive(false);
        }
    }
    public void FixedUpdate()
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
        
        Quaternion rotationWeWnat = Quaternion.LookRotation(walkDirection);
        actualBodyModel.transform.rotation = Quaternion.RotateTowards(actualBodyModel.transform.rotation, rotationWeWnat, bodyRotateSpeed);
        transform.Translate(move * Time.deltaTime * movespeed);
    }
}
