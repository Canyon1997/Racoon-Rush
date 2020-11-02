using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
	public float movementSpeed = 3f;
	public Transform player;

	private void FixedUpdate()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);

		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
           Debug.Log("Hit Detected. You Lose!!");
           SceneManager.LoadScene("SantisLoseScreen");
        }
        
    }
}