using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Character")]
    public float moveSpeed;

    [Header("UI")]
    public Text scoreText;
    private int score = 0;
    private float lastUpdate = 0;

    public Text highScore;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ScoreUI();
        HighScore();
    }

    private void Update()
    {
        //UI Display & Updates
        ScoreUI();
        IncreaseScore();

        ResetHighScore();
    }

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude >= moveSpeed)
        {
            return;
        }

        rb.AddForce(Vector2.right * moveSpeed);
    }

    private void IncreaseScore()
    {
        if(Time.time - lastUpdate >= 1f)
        {
            score++;
            lastUpdate = Time.time;
        }
    }


    //UI
    public void ScoreUI()
    {
        scoreText.text = "Score " + score.ToString();

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            //Get a particle effect/sound to congratulate new high score
            highScore.text = "High Score: " + score.ToString();
        }
        
    }

    void HighScore()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void ResetHighScore()
    {
        //Press during game to reset high score to 0
        if(Input.GetKey(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
        }
        
    }
}
