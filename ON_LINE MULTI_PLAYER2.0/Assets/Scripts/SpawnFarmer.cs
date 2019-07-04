using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFarmer : MonoBehaviour
{
    public GameObject farmer;
    public GameObject[] spawnFarmerLoc;
    public GameObject farmerSpawnPoint;
    public bool spawn;
    public bool auto;

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            BuyFarmer();
            spawn = false;
        }
    }
    public void BuyFarmer()
    {
        for (int i = 0; i < spawnFarmerLoc.Length; i++)
        {
            if(spawnFarmerLoc[i].GetComponent<Goal>().house == false)
            {
                Instantiate(farmer, farmerSpawnPoint.transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
