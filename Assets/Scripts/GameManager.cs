using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool ended = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    private PlayerCollision playerCollision;

    private void Start()
    {
        playerCollision = GameObject.Find("Main").GetComponent<PlayerCollision>();
    }

    public void EndGame()
    {
        if (ended == false)
        {
            ended = true;
            float finalScore = playerCollision.getCurrentScore();
            PlayerPrefs.SetFloat("Player Score", finalScore);
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Level01");
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
}
