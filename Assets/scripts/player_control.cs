using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public Rigidbody rb;

    public float run_speed;
    public float[] run_input;

    public float dashMuti;
    public float dash_cooldown;
    public bool dash_act;
    public float dash_down;

    public float jump_power;
    public float jump_power_act;
    public int jumps;
    public int jump_holder_x;

    Vector2 rotation = Vector2.zero;
    public float lookSpeed;
    public float speed;
    

    void Start()
    {
         rb = GetComponent<Rigidbody>();

        jump_holder_x = jumps;
    }

    
    void Update()
    {
        Debug.Log(Time.time);
        run_input[0] = 0;
        run_input[1] = 0;
        run_input[2] = 0;
        run_input[3] = 0;

        if (dash_act == true & dash_cooldown < Time.time)
        {
            run_speed = 7;
        }

        if (dash_down < Time.time & dash_act == true)
        {
            dash_act = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) & dash_act == false)
        {
            run_speed = run_speed * dashMuti;
            dash_act = true;
            dash_cooldown = Time.time + 0.1f;
            dash_down = Time.time + 1f;
        }

        if (Input.GetKey("w"))
        {
            run_input[0] = run_speed;
        }
        if (Input.GetKey("s"))
        {
            run_input[1] = -run_speed;
        }
        if (Input.GetKey("d"))
        {
            run_input[2] = run_speed;
        }
        if (Input.GetKey("a"))
        {
            run_input[3] = -run_speed;
        }

        jump_power_act = -jump_power/500;

        if (Input.GetKeyDown("space") & jumps > 0)
        {
            jump_power_act = jump_power;
            jumps--;
        }

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);

        rb.AddRelativeForce(run_input[2]+run_input[3], jump_power_act, run_input[0] + run_input[1]);
    }
    private void OnCollisionEnter(Collision collision)
    {
        jumps = jump_holder_x;
    }
}
