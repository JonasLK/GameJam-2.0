using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDropper : AIUsable
{
    public float minecartLowerAmount;
    public float lowerSpeed;

    public float cashHolding;
    public float cashCapacity;

    public Coroutine currentGenerationRoutine;

    public override void Start()
    {
        currentGenerationRoutine = StartCoroutine(GenerateDrops());
    }

    public override void Use(GameObject user)
    {
        base.Use(user);
        StartCoroutine(StartLoading(user, user.GetComponent<ValuableTransporter>().loadSpeed));
    }
    public IEnumerator StartLoading(GameObject collectorToDropInto, float loadDelayPerAmount)
    {
        Vector3 ogPosition = collectorToDropInto.transform.position;

        while(Vector3.Distance(collectorToDropInto.transform.position, ogPosition + new Vector3(0, minecartLowerAmount, 0)) > 0.2f)
        {
            collectorToDropInto.transform.position = Vector3.MoveTowards(collectorToDropInto.transform.position, ogPosition + new Vector3(0, minecartLowerAmount, 0), lowerSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(currentGenerationRoutine);
        while(cashHolding > 0)
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
        StartCoroutine(collectorToDropInto.GetComponent<ValuableTransporter>().MoveToDestination());
    }
    public abstract IEnumerator GenerateDrops();
}
