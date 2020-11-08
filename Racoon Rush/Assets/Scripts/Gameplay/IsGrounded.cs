using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public bool grounded;
    public float rayDistance;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance);

        if(hit.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
