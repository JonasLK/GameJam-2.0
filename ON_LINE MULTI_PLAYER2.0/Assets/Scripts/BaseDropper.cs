using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDropper : BaseMachine
{
    public GameObject dropObject;
    public Transform dropPoint;
    public float minecartLowerAmount;
    public float lowerSpeed;
    public int dropAmount;
    public int oreCapacity;

    public GameObject cart;
    // Start is called before the first frame update

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(StartLoading(cart, 0.3f));
        }
    }
    public IEnumerator StartLoading(GameObject collectorToDropInto, float loadDelay)
    {
        Vector3 ogPosition = collectorToDropInto.transform.position;

        while(Vector3.Distance(collectorToDropInto.transform.position, ogPosition + new Vector3(0, minecartLowerAmount, 0)) > 0.2f)
        {
            collectorToDropInto.transform.position = Vector3.MoveTowards(collectorToDropInto.transform.position, ogPosition + new Vector3(0, minecartLowerAmount, 0), lowerSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        int amountToDrop = dropAmount;
        for (int droppedAmount = 0; droppedAmount < amountToDrop; droppedAmount++)
        {
            dropAmount--;
            yield return new WaitForSeconds(loadDelay);
        }

        //LOADING SHIT IN
        while (Vector3.Distance(collectorToDropInto.transform.position, ogPosition) != 0)
        {
            collectorToDropInto.transform.position = Vector3.MoveTowards(collectorToDropInto.transform.position, ogPosition, lowerSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(collectorToDropInto.GetComponent<Minecart>().MoveToOrigin());
        /*
        int amountToDrop = dropAmount;
        for(int droppedAmount = 0; droppedAmount < amountToDrop; droppedAmount++)
        {
            yield return new WaitForSeconds(loadDelay);
            Instantiate(dropObject, dropPoint.transform.position, Quaternion.identity);
        }
        dropAmount -= amountToDrop;
        //Tell collector to proceed*/
    }
    public abstract IEnumerator GenerateDrops();
}
