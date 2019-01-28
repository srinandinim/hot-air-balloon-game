using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCircle : MonoBehaviour {

    private CubeFormationController cubeFormation;
    private CircleFormationController circleFormation;
    private PlayerCollision collision;

	void Start () {
        cubeFormation = GameObject.Find("CubeFormation").GetComponent<CubeFormationController>();
        circleFormation = GameObject.Find("CircleFormation").GetComponent<CircleFormationController>();
        collision = GameObject.Find("Main").GetComponent<PlayerCollision>();
        transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Balloon"))
        {
            collision.addScore(25);
            cubeFormation.setCurrent();
            circleFormation.setCurrent();
        }
    }
}
