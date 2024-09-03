using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform projectileSpawn;

    public GameObject projectile;

    public float fireRate = 0.5f;
    public float nextFire = 0.0f;

    public AudioClip shootSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        projectileSpawn = this.gameObject.transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    public void shoot()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            if (shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }

            nextFire = Time.time + fireRate;

            Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
        }
    }
}
