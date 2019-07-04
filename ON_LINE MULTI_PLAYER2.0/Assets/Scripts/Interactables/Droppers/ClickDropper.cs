using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDropper : BaseDropper
{

    public void GenerateDrop()
    {
        //StartCoroutine(GenerateDrops());
        amountHolding = Mathf.Min(amountHolding + 1, amountCapacity);
    }
    public override IEnumerator GenerateDrops()
    {
        amountHolding = Mathf.Min(amountHolding + 1, amountCapacity);
        yield return null;
    }
}
