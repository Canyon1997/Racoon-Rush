using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpForce;

    private bool jumped;
    public int maxJumps;

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
            maxJumps++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            maxJumps = 0;
        }
    }
}
