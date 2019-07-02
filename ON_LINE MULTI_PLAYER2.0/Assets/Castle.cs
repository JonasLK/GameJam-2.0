using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Goal
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Farmer")
        {
            nextGoal = other.gameObject.GetComponent<Farmer>().house.transform;
        }
    }
}
