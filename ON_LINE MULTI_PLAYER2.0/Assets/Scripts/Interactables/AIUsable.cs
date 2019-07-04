using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUsable : BaseMachine
{
    public Transform interactPoint;
    public virtual void Use(GameObject user)
    {
        user.GetComponent<ValuableTransporter>().currentWantedDestination++;
    }
}
