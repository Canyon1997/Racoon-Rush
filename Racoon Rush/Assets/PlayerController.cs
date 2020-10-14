using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float jumpForce;
    public float rayLength;

    public bool jump;
    public bool isGrounded;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        RayCast();

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       if(jump)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }

    private void RayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength);

        if(hit.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
