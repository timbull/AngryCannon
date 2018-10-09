using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrelController : MonoBehaviour {

    public float speed = 2;
    Vector3 movement;
    Rigidbody GunBarrelRB;

    private void Start()
    {
        GunBarrelRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        //Turning();
        //Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(0f, v, 0f);
        //movement = movement.normalized * speed * Time.deltaTime;

        GunBarrelRB.AddForce(movement, ForceMode.Force);
    }
}
