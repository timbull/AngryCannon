using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireController : MonoBehaviour {

    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public GameObject cannonBall;
    public ShotManager shotManager;
    public AudioSource cannonBoomAS;
    public AudioSource emptyClickAS;

    Light gunFireLight;
    float timer;
    float effectsDisplayTime = 0.2f;
    ParticleSystem muzzleFlash;

    // Use this for initialization
    void Awake () {
        gunFireLight = GetComponent<Light>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            CanShoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    void DisableEffects()
    {
        gunFireLight.enabled = false;
    }

    void CanShoot()
    {
        if (shotManager.Shoot())
        {
            Shoot();
        } else
        {
            // We're empty!
            emptyClickAS.Stop();
            emptyClickAS.Play();

        }
    }

    void Shoot()
    {
        timer = 0;
        gunFireLight.enabled = true;

        cannonBoomAS.Stop();
        cannonBoomAS.Play();
        muzzleFlash.Stop();
        muzzleFlash.Play();

        generateCannonBall();

    }

    void generateCannonBall()
    {
        GameObject cbClone = Instantiate(cannonBall, transform.position, transform.rotation);
        CannonBallManager cbCloneManager = cbClone.GetComponent<CannonBallManager>();
        cbCloneManager.timeInWorld = 5f;
        cbCloneManager.gunSpawnPoint = transform;
    }
}
