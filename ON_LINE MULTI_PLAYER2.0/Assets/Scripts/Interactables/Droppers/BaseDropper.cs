using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDropper : AIUsable
{
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
    public virtual IEnumerator StartLoading(GameObject collectorToDropInto, float loadDelayPerAmount)
    {
        yield return null;
    }
    public abstract IEnumerator GenerateDrops();
}
