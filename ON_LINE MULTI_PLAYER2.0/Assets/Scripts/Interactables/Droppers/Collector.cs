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
    public void Collect(float value)
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().currency += value * GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().currencyBoost;
    }
}
