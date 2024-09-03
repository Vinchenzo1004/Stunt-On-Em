using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform projectileSpawn;

    public GameObject projectile;

    public float fireRate = 1.5f;
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
        enemyShoot();
    }

    public void enemyShoot()
    {
        if(Time.time > nextFire)
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
