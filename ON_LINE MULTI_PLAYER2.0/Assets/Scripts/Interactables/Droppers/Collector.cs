using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : AIUsable
{

    public override void Use(GameObject user)
    {
        base.Use(user);
        StartCoroutine(user.GetComponent<ValuableTransporter>().Unload(gameObject));
    }
    public void Collect(float value, CollectableType currencyType)
    {
        if(currencyType == CollectableType.Currency)
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().currency += value * GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().currencyBoost;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().food += value;
        }
    }
    public enum CollectableType { Currency, Food}
}
