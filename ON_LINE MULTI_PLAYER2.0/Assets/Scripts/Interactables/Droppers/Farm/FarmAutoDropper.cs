using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAutoDropper : AutoDropper
{
    public override IEnumerator StartLoading(GameObject collectorToDropInto, float loadDelayPerAmount)
    {
        return base.StartLoading(collectorToDropInto, loadDelayPerAmount);
    }
}
