using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Enemy")]
    [SerializeField] private float enemyMoveSpeed;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    /*private void Update()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
	}*/

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude > enemyMoveSpeed)
        {
            return;
        }

        rb.AddForce(Vector2.right * enemyMoveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Raccoon")
        {
           Debug.Log("Hit Detected. You Lose!!");
           SceneManager.LoadScene("SantisLoseScreen");
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TrashCan"))
        {
            Destroy(other.gameObject);
        }
    }
}