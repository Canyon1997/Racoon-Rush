using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
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
      else if(!jumped)
        {
            jumped = Input.touches[0].phase == TouchPhase.Began;
        }
    }

    private void FixedUpdate()
    {
        if(jumped && maxJumps == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
            sounds.PlayOneShot(jumpSound);
            maxJumps++;
            animator.SetBool("HasJumped", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            maxJumps = 0;
            jumped = false;
            animator.SetBool("HasJumped", false);
        }
    }
}
