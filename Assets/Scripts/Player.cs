using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField] float jumpForce = 5f;
    bool IsGrounded = true;
    bool IsInventoryActive;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    [SerializeField] GameObject inventoryUI;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryUI.SetActive(!IsInventoryActive);
            IsInventoryActive = !IsInventoryActive;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

}
