using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public Transform collectionPoint;

    public void Collect(float value)
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().currency += value * GameObject.FindGameObjectWithTag("Manager").GetComponent<LocalGameManager>().currencyBoost;
    }
}
