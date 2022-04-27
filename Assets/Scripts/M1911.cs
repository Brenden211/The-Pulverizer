using UnityEngine;

public class M1911 : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 50f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Animator M1911Animator;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
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

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}
