using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDropper : BaseDropper
{
    public float generateDelay;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        currentGenerationRoutine = StartCoroutine(GenerateDrops());
    }

    public override IEnumerator GenerateDrops()
    {
        while (true)
        {
            yield return new WaitForSeconds(generateDelay);
            amountHolding = Mathf.Min(amountHolding + 1, amountCapacity);
        }
    }
}
