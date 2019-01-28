using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour {

    private List<GameObject> individualCubes = new List<GameObject>();

	void Start () {
		foreach (Transform child in transform)
        {
            GameObject currentCube = child.transform.gameObject;
            currentCube.GetComponent<BoxCollider>().enabled = false;
            individualCubes.Add(currentCube);
        }
        playAnimation();
	}

    void playAnimation()
    {
        foreach (GameObject child in individualCubes)
        {
            Animator anim = child.GetComponent<Animator>();
            anim.SetBool("playAnimation", true);
        }
    }
}
