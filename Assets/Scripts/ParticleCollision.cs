using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour {

    private bool hit;
    private PlayerMovement movement;

    private void Start()
    {
        hit = false;
        movement = GameObject.Find("Main").GetComponent<PlayerMovement>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Balloon"))
        {
            hit = true;
            movement.setForwardForce(20f, false);
        }
    }

    public bool getHit()
    {
        return hit;
    }
}
