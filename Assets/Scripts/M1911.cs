using UnityEngine;

public class M1911 : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public Animator M1911Animator;
    public GameUI gameUIScript;
    public Camera fpsCam;

    public int damage;
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
        muzzleFlash.Play(); // Plays the animation for the muzzle flash
        M1911Animator.SetTrigger("Shoot"); // Sets the M1911 animator trigger for shoot
        FindObjectOfType<AudioManager>().Play("M1911"); // Finds the audio clip in the AudioManager and plays the name of it

        RaycastHit hit; // Uses a raycast and stores the data from it in the hit variable

        //Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red, 15f);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) // If statement to check if the raycast from the camera position hit something
        {
            Debug.Log(hit.transform.name); // Debug statement to say what the raycast hit

            // References the EnemyHealthBar script and stores it the variable which is equal to the raycast hit's objects EnemyHealthBar component
            EnemyHealthBar enemyHealthBar = hit.transform.GetComponent<EnemyHealthBar>();

            if (enemyHealthBar != null) // If statement to check if the enemyHealthBar component is null if its not then it does the following
            {
                enemyHealthBar.EnemyTakeDamage(damage); // Tells the enemyHealthBar script to do the function with the input amount
            }
            else // If it doesn't have a enemyHealthBar component it does the following
            {
                return;
            }
        }
    }
}
