using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerx : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    public float xRange = 10.0f;
    public float gravityModifier;

    public float jumpForce = 10f; 
    public int maxJumps = 50; 
    private int jumpCount = 0; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump();
        }
        // Keep player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Player can move left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        jumpCount++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
        
    }
}
    