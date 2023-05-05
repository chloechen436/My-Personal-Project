using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerx : MonoBehaviour
{
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public float gravityModifier;
    //public GameObject fireworkparticlePrefab;
    public ParticleSystem fireworkParticle;
    public float jumpForce = 10f; 
    public int maxJumps = 50;

    private Rigidbody playerRb;
    private Rigidbody rb;
    private int jumpCount = 0; 

    private AudioSource playerAudio;

    public AudioClip goodToppingSound;
    public AudioClip badToppingSound;

    public bool isOnGround = true;
    public bool gameOver;

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
            isOnGround = false;
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

        /*if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            isOnGround = false;
        }*/
    }

        // Jump Controls
    private void Jump()
    {
        if (jumpCount == 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            jumpCount++;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Resetting jumps to 0.");
            jumpCount = 0;
            isOnGround = true;
        }
    
        if(collision.gameObject.CompareTag("Enemy"))
        {
         Debug.Log("Player has collided with enemy.");
        }

        if (collision.gameObject.CompareTag("Good Topping"))
        {
            Debug.Log("Player has collided with Good Topping.");
        }

        if (collision.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Firework Particles should play");
            fireworkParticle.Play();
        }
    }

       // Prefabs are destroyed on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Good Topping"))
        {
            Destroy(other.gameObject);
        }
    }

}
    