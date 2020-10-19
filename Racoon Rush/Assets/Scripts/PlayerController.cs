using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;


    public float jumpForce;

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
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }

    }
}
