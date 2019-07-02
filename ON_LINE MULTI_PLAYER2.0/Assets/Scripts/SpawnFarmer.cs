using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFarmer : MonoBehaviour
{
    public GameObject farmer;
    public GameObject houseFarmer;
    public bool spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            Instantiate(farmer, houseFarmer.transform.position, Quaternion.identity);
            spawn = false;
        }
    }
    public void SetFarmer()
    {
        if(farmer.GetComponent<Farmer>().house != null)
        {
            farmer.GetComponent<Farmer>().house = houseFarmer;
        }
    }
}
