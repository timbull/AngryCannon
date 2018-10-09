using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallManager : MonoBehaviour {

    public Transform gunSpawnPoint;
    public float timeInWorld;
    public float fireSpeed = 15f;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        // Orient myself to the gunSpawnPoint
        transform.SetPositionAndRotation(gunSpawnPoint.position, gunSpawnPoint.rotation);

        // Assign my RB
        rb = gameObject.GetComponent<Rigidbody>();

        rb.velocity = transform.up * fireSpeed;
        // Do the work of destroying myself here once.
        Destroy(gameObject, timeInWorld);
    }

    // Update is called once per frame
    void Update () {
        
    }
}
