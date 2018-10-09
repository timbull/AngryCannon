using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBodyController : MonoBehaviour {

    public float rotationSpeed = 30.0f;
    Vector3 movement;

	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {
    
        float v = Input.GetAxisRaw("Horizontal");
        
        if (v != 0)
        {
            // If we're turning then apply the direction.
            // The input is either 1 or -1
            Turning(v);
        }
        
    }

    private void Turning(float v)
    {
        movement.Set(0f, v, 0f);
        transform.Rotate(transform.position, v * rotationSpeed * Time.deltaTime);

    }

}
