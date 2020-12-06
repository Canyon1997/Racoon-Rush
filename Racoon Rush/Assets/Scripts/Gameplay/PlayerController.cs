using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public static float staticMovementSpeed;

    private float savedSpeed;
    private float maxSpeed = 15f; //max amount that the character's speed can go 

    [Header("Character")]
    public float moveSpeed;
    private float originalMoveSpeed;

    [Header("Audio")]
    public AudioSource sounds;
    public AudioClip pickupSound;

    [Header("UI")]
    public Text scoreText;
    private int score = 0;
    private float lastUpdate = 0;
    public Text highScore;

    [Header("PowerUp Speed and Time")]
    [SerializeField] private float candyMoveSpeedIncrease;
    [SerializeField] private float candyPowerUpTime;

    private bool hitCandy;

    [Header("Trap Speed and Times")]
    [SerializeField] private float trashCanPenaltySpeed;
    [SerializeField] private float mouseTrapPenaltySpeed;

    [SerializeField] private float mouseTrapPenaltyTime;
    [SerializeField] private float trashPenaltyTime;

    private bool hitTrashCan;
    private bool hitMouseTrap;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ScoreUI();
        HighScore();

        originalMoveSpeed = moveSpeed;
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
        if (other.gameObject.CompareTag("Trash"))
        {
            score += 100;
            sounds.PlayOneShot(pickupSound);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Trap"))
        {
            if(!hitMouseTrap && !hitTrashCan)
            {
                StartCoroutine(MouseTrapSlow());
                hitMouseTrap = true;
                //Need a sound for this
            }
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("Candy"))
        {
            if(!hitCandy)
            {
                StartCoroutine(CandySpeedIncrease());
                hitCandy = true;
                //Need sound for this
            }
            Destroy(other.gameObject);

        }

        else if(other.gameObject.CompareTag("TrashCan"))
        {
            if(!hitTrashCan)
            {
                StartCoroutine(TrashCanSlow());
                hitTrashCan = true;
                //Need sound for this
            }
            Destroy(other.gameObject);
        }
    }

    IEnumerator CandySpeedIncrease()
    {
        moveSpeed = candyMoveSpeedIncrease;
        yield return new WaitForSeconds(candyPowerUpTime);
        moveSpeed = originalMoveSpeed;
        hitCandy = false;
    }

    IEnumerator MouseTrapSlow()
	{
        moveSpeed = mouseTrapPenaltySpeed;
		yield return new WaitForSeconds(mouseTrapPenaltyTime);
		moveSpeed = originalMoveSpeed;
		hitMouseTrap = false;
	}

    IEnumerator TrashCanSlow()
    {
        moveSpeed = trashCanPenaltySpeed;
        yield return new WaitForSeconds(trashPenaltyTime);
        moveSpeed = originalMoveSpeed;
        hitTrashCan = false;
    }
}
