using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerGo : MonoBehaviour
{
    public List<GameObject> farmer = new List<GameObject>();
    public float goTimer;
    public bool go;

    public void Update()
    {
        if (go)
        { 
            StartCoroutine(GoFarmer());
            go = false;
        }
    }
    IEnumerator GoFarmer()
    {
        for (int i = 0; i < farmer.Count; i++)
        {
            yield return new WaitForSeconds(goTimer);
            farmer[i].GetComponent<Farmer>().go = true;
        }
            yield return GoFarmer();
    }
    
}
