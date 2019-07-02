using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDropper : BaseMachine
{
    public GameObject dropObject;
    public Transform dropPoint;
    public int dropAmount;
    public int oreCapacity;
    // Start is called before the first frame update

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(StartDropping(gameObject, 0.3f));
        }
    }
    public IEnumerator StartDropping(GameObject collectorToDropInto, float loadDelay)
    {
        int amountToDrop = dropAmount;
        for(int droppedAmount = 0; droppedAmount < amountToDrop; droppedAmount++)
        {
            yield return new WaitForSeconds(loadDelay);
            Instantiate(dropObject, dropPoint.transform.position, Quaternion.identity);
        }
        dropAmount -= amountToDrop;
        //Tell collector to proceed
    }
    public abstract IEnumerator GenerateDrops();
}
