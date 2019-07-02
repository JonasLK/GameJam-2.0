using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Farmer : MonoBehaviour
{
    public GameObject house;
    public Transform goal;
    public NavMeshAgent agent;
    public float goalReached;
    public float maxcooldown;
    public float cooldown;
    public bool go;
    public bool auto;

    public void Awake()
    {
        house = GameObject.FindGameObjectWithTag("House");
        cooldown = maxcooldown;
        if(house != null)
        {
            goal = house.transform;
        }
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float dis = Vector3.Distance(transform.position, goal.position);
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
                if (auto == false)
                {
                    go = false;
                }
                cooldown = maxcooldown;
            }
        }
    }
}
