using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;
    private ParticleCollision particleCollision;
    private PlayerCollision playerCollision;

    bool hit;

    private void Start()
    {
        particleCollision = GameObject.Find("BirdSystem").GetComponent<ParticleCollision>();
        playerCollision = GameObject.Find("Main").GetComponent<PlayerCollision>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Balloon"))
        {
            hit = particleCollision.getHit();
            if (hit == false)
                playerCollision.addScore(10);
            
            gameManager.CompleteLevel();
        }
    }
}
