﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAutoDropper : AutoDropper
{
    public GameObject[] carrots;
    public float carrotFadeSpeed;
    public override IEnumerator StartLoading(GameObject collectorToDropInto, float loadDelayPerAmount)
    {
        StopCoroutine(currentGenerationRoutine);
        float foodToadd = 0;
        for(int i = 0; i < amountHolding; i++)
        {
            yield return new WaitForSeconds(loadDelayPerAmount);
            GameObject carrotSelected = carrots[i];
            Vector3 ogPosition = carrotSelected.transform.position;
            foodToadd += carrotSelected.GetComponent<CurrencyDrop>().value;
            StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().FadeObject(false, carrotFadeSpeed, carrotSelected, false));
        }
        collectorToDropInto.GetComponent<ValuableTransporter>().amountHolding += foodToadd;
        amountHolding = 0;
        StartCoroutine(collectorToDropInto.GetComponent<ValuableTransporter>().MoveToDestination());
        currentGenerationRoutine = StartCoroutine(GenerateDrops());
    }
    public override IEnumerator GenerateDrops()
    {
        print("AYY");
        while(amountHolding < amountCapacity)
        {
            yield return new WaitForSeconds(generateDelay);
            if(amountHolding < amountCapacity)
            {
                amountHolding++;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().FadeObjectIn(carrots[(int)amountHolding - 1]);
            }
        }
    }
}
