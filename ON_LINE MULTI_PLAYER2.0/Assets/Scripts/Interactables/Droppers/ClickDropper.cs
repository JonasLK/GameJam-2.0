using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDropper : BaseDropper
{

    public void GenerateDrop()
    {
        //StartCoroutine(GenerateDrops());
        cashHolding = Mathf.Min(cashHolding + 1, cashCapacity);
    }
    public override IEnumerator GenerateDrops()
    {
        cashHolding = Mathf.Min(cashHolding + 1, cashCapacity);
        yield return null;
    }
}
