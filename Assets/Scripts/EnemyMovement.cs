using System.Collections.Generic;
using System.Collections;
using UnityEngine.Animations;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Variable to reference the object we want to move towards
    public Transform target;
    public Animator eAnimator;

    private NavMeshAgent agent;

    public float updateFrequency = 0.1f;
    public bool chaseTarget = false;
    
    private float updateCounter = 0;

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
        if (updateCounter >= updateFrequency && chaseTarget == true)
        {
            // Sets the Walk Forward bool to true
            eAnimator.SetBool("Walk Forward", true);

            // Sets the agent's destination to the target's position
            agent.SetDestination(target.position);

            updateCounter = 0;
        }

        else
        {
            updateCounter += Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Target"))
        {
            eAnimator.SetTrigger("Stab Attack");
        }
    }
}
