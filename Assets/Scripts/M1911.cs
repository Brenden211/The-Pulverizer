using UnityEngine;

public class M1911 : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public Animator M1911Animator;
    public GameUI gameUIScript;
    public Camera fpsCam;

    public float damage;
    public float impactForce;
    public float fireRate;
    public float range = 500f;
    private float nextTimeToFire = 0f;
    public int aimIndex = 0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && gameUIScript.gameIsPaused == false)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButtonDown("Fire2") && gameUIScript.gameIsPaused == false && aimIndex == 0)
        {
            M1911Animator.SetBool("Aim", true);
            aimIndex = 1;
        }
        else if (Input.GetButtonDown("Fire2") && gameUIScript.gameIsPaused == false && aimIndex == 1)
        {
            M1911Animator.SetBool("Aim", false);
            aimIndex = 0;
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        M1911Animator.SetTrigger("Shoot");
        FindObjectOfType<AudioManager>().Play("M1911");

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyHealthBar enemyHealthBar = hit.transform.GetComponent<EnemyHealthBar>();

            if (enemyHealthBar != null)
            {
                enemyHealthBar.EnemyTakeDamage(10);
            }
            else
            {
                return;
            }
        }

        return;
    }
}
