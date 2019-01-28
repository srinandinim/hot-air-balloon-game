using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    private PlayerCollision playerCollision;

    private void Start()
    {
        playerCollision = GameObject.Find("Main").GetComponent<PlayerCollision>();
    }

    public void LoadNextLevel()
    {
        float finalScore = playerCollision.getCurrentScore();
        PlayerPrefs.SetFloat("Player Score", finalScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
