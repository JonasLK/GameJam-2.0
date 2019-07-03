using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Farmer : MonoBehaviour
{
    public GameObject house;
    public GameObject castle;
    public Transform goal;
    public NavMeshAgent agent;
    public GameObject farmManager;
    public float goalReached;
    public float maxcooldown;
    public float cooldown;
    public bool go;
    public bool auto;

    public void Awake()
    {
        farmManager = GameObject.FindGameObjectWithTag("Spawner");
        castle = GameObject.FindGameObjectWithTag("Castle");
        SpawnFarmer houseLoc = farmManager.GetComponent<SpawnFarmer>();
        farmManager.GetComponent<FarmerGo>().farmer.Add(gameObject);
        cooldown = maxcooldown;
        if(house == null)
        {
            for (int i = 0; i < houseLoc.spawnFarmerLoc.Length; i++)
            {
                if (houseLoc.spawnFarmerLoc[i].GetComponent<Goal>().house == false)
                {
                    house = houseLoc.spawnFarmerLoc[i];
                    houseLoc.spawnFarmerLoc[i].GetComponent<Goal>().house = true;
                    goal = house.transform;
                    break;
                }
                else
                {
                    Debug.Log("No more houses");
                }
            }
        }
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float dis = Vector3.Distance(transform.position, goal.position);
        SpawnFarmer automaticCheck = farmManager.GetComponent<SpawnFarmer>();
        if (automaticCheck.auto)
        {
            auto = true;
        }
        if (go)
        {
            agent.SetDestination(goal.position);
        }
        else
        {
            agent.SetDestination(house.transform.position);
        }
        if(dis <= goalReached)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                goal = goal.GetComponent<Goal>().nextGoal;
                if(goal == house.transform && auto == false)
                {
                    go = false;
                }
                cooldown = maxcooldown;
            }
        }
    }
}
