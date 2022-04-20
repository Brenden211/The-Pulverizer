using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    // Variable to reference the object we want to move towards
    public Transform target;
    public float updateFrequency = 0.1f;
    public bool trackTarget = false;

    private float updateCounter = 0;
    private NavMeshAgent agent;

    void Start()
    {
        // If statement to check if the target is referenced
        if (target != null)
        {
            // If target is not null then it sets the agent variable to the object's NavMeshAgent component
            agent = this.transform.GetComponent<NavMeshAgent>();

            // Sets target to the game object with the following tag
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }


    void Update()
    {
        if (updateCounter >= updateFrequency && trackTarget == true)
        {
            // Sets the agent's destination to the target's position
            agent.SetDestination(target.position);

            updateCounter = 0;
        }
        else
        {
            updateCounter += Time.deltaTime;
        }
    }
}
