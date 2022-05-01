using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public Animator eAnimator;
    private NavMeshAgent agent;

    public float updateFrequency = 0.1f;
    private float updateCounter = 0;

    public bool chaseTarget = false;

    void Start()
    {
        if (target != null)
        {
            agent = this.transform.GetComponent<NavMeshAgent>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (updateCounter >= updateFrequency)
        {
            eAnimator.SetBool("Walk Forward", true);

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

    public void Die()
    {
        eAnimator.SetTrigger("Die");
        Destroy(gameObject);
    }
}
