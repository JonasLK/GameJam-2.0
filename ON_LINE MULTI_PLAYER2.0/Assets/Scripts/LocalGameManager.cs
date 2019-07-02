using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGameManager : MonoBehaviour
{
    public float currency;
    public float currencyBoost = 1;
    public float food;
    public float population;
    public float populationCapacity;
    public float populationPerPercentageBoost;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void RecalculatePopulationBoost()
    {
        currencyBoost = (population / populationPerPercentageBoost) + 1;
    }
}
