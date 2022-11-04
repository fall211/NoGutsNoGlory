using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    private Rigidbody2D bobber_rigidbody;
    public bool in_water;
    public float buoyancy_force = 1f;

    void Start()
    {
        bobber_rigidbody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (in_water) {
            bobber_rigidbody.velocity += new Vector2(0,buoyancy_force * Time.deltaTime);
        }
    }
}
