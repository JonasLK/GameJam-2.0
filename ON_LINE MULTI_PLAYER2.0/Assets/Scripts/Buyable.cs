using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buyable : MonoBehaviour
{
    public float fadeSpeed;
    public bool canBuy = true;
    public float cost;
    LocalGameManager l;
    public UnityEvent buyEvent;

    public void Start()
    {
        l = GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>();
    }
    public void Buy()
    {
        if(l.currency >= cost)
        {
            l.currency -= cost;
            canBuy = false;
            buyEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
