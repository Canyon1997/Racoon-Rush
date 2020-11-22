using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
	public float movementSpeed = 3f;

    private void Update()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Raccoon")
        {
           Debug.Log("Hit Detected. You Lose!!");
           SceneManager.LoadScene("SantisLoseScreen");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("TrashCan"))
        {
            Destroy(other.gameObject);
        }
    }
}