using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    public float populationCapacityModifier;
    public float capacity;
    public float currentAmount;
    public float generationDelay;
    public float foodConsumption;
    void Start()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().populationCapacity += populationCapacityModifier;
        StartCoroutine(StartPopgeneration());
    }

    public IEnumerator StartPopgeneration()
    {
        LocalGameManager manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>();
        while (currentAmount < capacity)
        {
            yield return new WaitForSeconds(generationDelay);
            if(currentAmount < capacity)
            {
                if(manager.food >= foodConsumption)
                {
                    currentAmount += 1;
                    manager.population += 1;
                    manager.food -= foodConsumption;
                    manager.RecalculatePopulationBoost();
                }
            }
        }
    }
}
