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
        StartCoroutine(GenerateDrops());
    }

    public override IEnumerator GenerateDrops()
    {
        while (true)
        {
            yield return new WaitForSeconds(generateDelay);
            dropAmount = Mathf.Min(dropAmount + 1, oreCapacity);
        }
    }
}
