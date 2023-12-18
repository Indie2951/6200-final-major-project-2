using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_platform : MonoBehaviour
{
    public Rigidbody rb;

    public bool activate;
    public bool unactivater;
    public bool unactivater2;
    public float resistance;
    public float time;
    public float time_track;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (activate == true & unactivater == false)
        {
            time_track = Time.time + time;
            unactivater = true;
        }

        if (rb.useGravity == false)
        {
            rb.useGravity = true;
        }

        if (activate == true & time_track < Time.time & unactivater2 == false)
        {
            unactivater2 = true;
            rb.drag = resistance;
            rb.useGravity = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Destroy(gameObject);
        }
        activate = true;
    }
}
