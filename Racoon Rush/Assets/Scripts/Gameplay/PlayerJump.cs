using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpForce;

    public bool jumped;
    public int maxJumps;

    [Header("Audio")]
    public AudioSource sounds;
    public AudioClip jumpSound;
    public AudioClip pickupSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(!jumped)
        {
            jumped = Input.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        if(jumped && maxJumps == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
            sounds.PlayOneShot(jumpSound);
            maxJumps++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            maxJumps = 0;
            jumped = false;
        }
    }
}
