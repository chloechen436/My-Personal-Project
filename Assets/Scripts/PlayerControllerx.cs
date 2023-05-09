using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerx : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody playerRb;
    public float xRange = 10.0f;
    public float gravityModifier;

    public float jumpForce = 10f; 
    public int maxJumps = 50; 
    private int jumpCount = 0; 

    public AudioSource playerAudio;

    public AudioClip goodTopping;
    public AudioClip badTopping;
    public AudioClip gameEnd;
    public AudioClip gameStart;
    public AudioClip powerUp;

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
        }
    
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with Enemy.");
            //try the sound here
            playerAudio.PlayOneShot(badTopping);
        }

        if (collision.gameObject.CompareTag("Good Topping"))
        {
            Debug.Log("Player has collided with Good Topping.");
            //try the sound here
            playerAudio.PlayOneShot(goodTopping);
        }

        if(collision.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Player has collided with Powerup.");
            //try the sound here
            playerAudio.PlayOneShot(powerUp);
        }

        //I don't see any bad topping prefabs or else I would add the sound for the bad topping collisions
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

    