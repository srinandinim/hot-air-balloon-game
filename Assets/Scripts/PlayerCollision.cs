using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    private int score;
    private float currentScore;
    private float previousScore;
    public Text scoreText;

    public PlayerMovement movement;

    private float startTime;
    private float currentTime;
    public float countdownStart;
    private float duration;

    private void Start()
    {
        score = 0;
        startTime = Time.time;
        countdownStart = 100f;
        setPreviousScore();
        setScoreText();
    }

    private void Update()
    {
        currentTime = Time.time;
        float timeTraveled = currentTime - startTime;
        duration = countdownStart - timeTraveled;
        setScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            score++;
            setScoreText();
        }
        if (other.gameObject.CompareTag("Water"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movement.setOnGround(true);
        }
    }

    public void addScore(int addValue)
    {
        score += addValue;
        setScoreText();
    }

    private void setScoreText()
    {
        currentScore = previousScore + score + duration;
        if (currentScore < 0) currentScore = 0;
        scoreText.text = currentScore.ToString("0");
    }

    public float getStartTime()
    {
        return startTime;
    }

    public float getCurrentScore()
    {
        return currentScore;
    }

    private void setPreviousScore()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Level01")
            previousScore = 0f;
        else
            previousScore = PlayerPrefs.GetFloat("Player Score");
    }
    
}
