using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDropper : AIUsable
{
    public float amountHolding;
    public float amountCapacity;

    public Coroutine currentGenerationRoutine;


    public override void Use(GameObject user)
    {
        base.Use(user);
        StartCoroutine(StartLoading(user, user.GetComponent<ValuableTransporter>().loadSpeed));
    }
    public virtual IEnumerator StartLoading(GameObject collectorToDropInto, float loadDelayPerAmount)
    {
        yield return null;
    }
    public abstract IEnumerator GenerateDrops();
}
