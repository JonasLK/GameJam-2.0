using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    public float populationCapacityModifier;
    void Start()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().populationCapacity += populationCapacityModifier;
    }
}
