using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController controller;

    [Header("Enemy")]
    [SerializeField] private float enemyMoveSpeed;
    private Difficulty level;

    private enum Difficulty
    {
        Level2,
        Level3,
        Level4
    };

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start()
    {
        controller = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        //EnemyDifficutly();
    }

    /*private void EnemyDifficutly()
    {
        //Score relation to level difficulty
        if (controller.score > 1000)
        {
            level = Difficulty.Level2;
        }
        else if(controller.score > 2500)
        {
            level = Difficulty.Level3;
        }
        else if(controller.score > 5000)
        {
            level = Difficulty.Level4;
        }

        //Speed multiplier to level difficulty
        switch(level)
        {
            case Difficulty.Level2:
                enemyMoveSpeed += 2;
                controller.moveSpeed += 2;
                break;

            case Difficulty.Level3:
                enemyMoveSpeed += 2;
                controller.moveSpeed += 2;
                break;

            case Difficulty.Level4:
                enemyMoveSpeed += 2;
                controller.moveSpeed += 1;
                break;
        }
    }*/

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude > enemyMoveSpeed)
        {
            return;
        }

        rb.AddForce(Vector2.right * enemyMoveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
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