using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineClickDropper : ClickDropper
{
    public float minecartLowerAmount;
    public float lowerSpeed;


    public override IEnumerator StartLoading(GameObject collectorToDropInto, float loadDelayPerAmount)
    {
        Vector3 ogPosition = collectorToDropInto.transform.position;

        while (Vector3.Distance(collectorToDropInto.transform.position, ogPosition + new Vector3(0, minecartLowerAmount, 0)) > 0.2f)
        {
            collectorToDropInto.transform.position = Vector3.MoveTowards(collectorToDropInto.transform.position, ogPosition + new Vector3(0, minecartLowerAmount, 0), lowerSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(currentGenerationRoutine);
        while (cashHolding > 0)
        {
            yield return new WaitForSeconds(loadDelayPerAmount);
            cashHolding--;
            collectorToDropInto.GetComponent<ValuableTransporter>().amountHolding++;
        }

        collectorToDropInto.GetComponent<ValuableTransporter>().valuableStack.SetActive(true);
        //LOADING SHIT IN
        while (Vector3.Distance(collectorToDropInto.transform.position, ogPosition) != 0)
        {
            collectorToDropInto.transform.position = Vector3.MoveTowards(collectorToDropInto.transform.position, ogPosition, lowerSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(GenerateDrops());
        StartCoroutine(collectorToDropInto.GetComponent<ValuableTransporter>().MoveToDestination());
    }
}
