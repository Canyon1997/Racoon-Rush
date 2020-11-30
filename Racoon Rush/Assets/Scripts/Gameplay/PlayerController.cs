using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Character")]
    public float moveSpeed;
    [SerializeField] private float candyMoveSpeedIncrease;

    [Header("Audio")]
    public AudioSource sounds;
    public AudioClip pickupSound;

    [Header("UI")]
    public Text scoreText;
    private int score = 0;
    private float lastUpdate = 0;

    private bool isSlowed;
    public static float staticMovementSpeed;
    public float trapSlowTime = 2f;
    private float savedSpeed;

    public Text highScore;

    private float maxSpeed = 15f; //max amount that the character's speed can go 

    

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

        QuitGame();
    }

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude >= moveSpeed)
        {
            return;
        }

        rb.AddForce(Vector2.right * moveSpeed);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed); //set's the limit of the raccoon's speed
    }

    private void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isSlowed)
		{
			staticMovementSpeed = moveSpeed;
		}
        
        if (other.gameObject.CompareTag("Trash"))
        {
			Destroy(other.gameObject);
            sounds.PlayOneShot(pickupSound);
            score += 100;
            
        }

        else if (other.gameObject.CompareTag("Trap"))
        {
            if (!isSlowed)
			{
				StartCoroutine(TrapSlow());
				isSlowed = true;
                //Need a sound for this pickup
			}
        }

        else if(other.gameObject.CompareTag("Candy"))
        {
            moveSpeed += candyMoveSpeedIncrease;
            Destroy(other.gameObject);
            //Need a sound for this pickup
        }
    }

    IEnumerator TrapSlow()
	{
		var savedSpeed = moveSpeed;
		moveSpeed -= (moveSpeed / 1.5f);
		yield return new WaitForSeconds(trapSlowTime);
		moveSpeed = savedSpeed;
		isSlowed = false;
	}
}
