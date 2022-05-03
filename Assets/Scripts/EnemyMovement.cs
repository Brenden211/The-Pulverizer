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
    public bool IsAlive = true;

    PlayerHealthBar playerHealthBar;

    Waves waves;

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
        if (updateCounter >= updateFrequency && IsAlive == true)
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

            playerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<PlayerHealthBar>();

            playerHealthBar.PlayerTakeDamage(10);

            return;
        }
        else
        {
            return;
        }
    }

    public void Die()
    {
        waves = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Waves>();
        waves.KillEnemy();

        eAnimator.SetTrigger("Die");
        Destroy(gameObject);
    }
}
