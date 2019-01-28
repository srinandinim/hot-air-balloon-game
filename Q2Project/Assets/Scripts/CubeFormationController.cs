using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFormationController : MonoBehaviour {

    private List<GameObject> individualFormations = new List<GameObject>();
    private int current;
    public GameObject player;

    void Start () {
        foreach (Transform child in transform)
        {
            GameObject currentCircle = child.transform.gameObject;
            currentCircle.GetComponent<CircleMovement>().enabled = false;
            individualFormations.Add(currentCircle);
        }
        individualFormations[current].GetComponent<CircleMovement>().enabled = true;
    }

    public void setCurrent()
    {
        current = current + 1;
        if (current < individualFormations.Count)
            individualFormations[current].GetComponent<CircleMovement>().enabled = true;
        
    }
	
	void Update () {
        	
	}
}
