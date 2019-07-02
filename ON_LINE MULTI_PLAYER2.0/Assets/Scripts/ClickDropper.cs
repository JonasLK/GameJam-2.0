using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDropper : BaseDropper
{

    public void GenerateDrop()
    {
        //StartCoroutine(GenerateDrops());
        dropAmount = Mathf.Min(dropAmount + 1, oreCapacity);
    }
    public override IEnumerator GenerateDrops()
    {
        dropAmount = Mathf.Min(dropAmount + 1, oreCapacity);
        yield return null;
    }
}
