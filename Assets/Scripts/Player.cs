using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField] float jumpForce = 5f;
    bool IsGrounded = true;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    Vector3 direction;

    void Update()
    {
        float MoveHor = Input.GetAxis("Horizontal");
        float MoveVer = Input.GetAxis("Vertical");

        direction = new Vector3(MoveHor, 0, MoveVer);
        direction = transform.TransformDirection(direction);
        if (MoveHor != 0 && MoveVer != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        if (IsGrounded == true)
        {
            anim.SetBool("Jump", false);
        }
        else if (IsGrounded == false)
        {
            anim.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            IsGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Fluid/lava":
                    //nothing here
                    break;
        }
    }
}
