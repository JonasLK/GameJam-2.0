using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayDay : ValuableTransporter
{
    public override IEnumerator Unload(GameObject objectToUnloadIn)
    {
        yield return null;
        objectToUnloadIn.GetComponent<Collector>().Collect(amountHolding * valueMultiplier);
        amountHolding = 0;
        StartCoroutine(MoveToDestination());
    }

}
