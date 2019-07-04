﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buyable : MonoBehaviour
{
    public float fadeSpeed;
    public bool canBuy = true;
    public float cost;
    public UnityEvent buyEvent;

        
    public void Buy()
    {
        canBuy = false;
        buyEvent.Invoke();
        Destroy(gameObject);
    }
}
