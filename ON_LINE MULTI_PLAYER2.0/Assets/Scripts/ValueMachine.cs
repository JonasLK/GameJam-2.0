using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueMachine : ModifyMachine
{
    public GameObject replacementObject;
    public float valueMultiplier;

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            GameObject objectToModify = other.gameObject;
            if (replacementObject)
            {
                GameObject oldObject = objectToModify;
                objectToModify = Instantiate(replacementObject, objectToModify.transform.position, objectToModify.transform.rotation);
                Destroy(oldObject);
            }
            objectToModify.GetComponent<CurrencyDrop>().value *= valueMultiplier;
        }
    }
}
