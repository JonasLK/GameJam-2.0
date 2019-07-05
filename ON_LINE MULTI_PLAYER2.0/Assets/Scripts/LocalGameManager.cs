using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalGameManager : MonoBehaviour
{
    public float currency;
    public Text cur;
    public float currencyBoost = 1;
    public float food;
    public Text fod;
    public float population;
    public Text pop;
    public float populationCapacity;
    public float populationPerPercentageBoost;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        int popul = (int)population;
        int popMax = (int)populationCapacity;
        int curr = (int)currency;
        int foood = (int)food;
        pop.text = popul.ToString() + " / " + popMax.ToString();
        fod.text = foood.ToString();
        cur.text = curr.ToString();
    }
    public void RecalculatePopulationBoost()
    {
        currencyBoost = (population / populationPerPercentageBoost) + 1;
    }
}
