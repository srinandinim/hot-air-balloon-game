using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFormationController : MonoBehaviour {

    private List<GameObject> individualCircles = new List<GameObject>();
    private int current;

    void Start () {
        foreach (Transform child in transform)
        {
            GameObject currentCircle = child.transform.gameObject;
            currentCircle.SetActive(false);
            individualCircles.Add(currentCircle);
        }
        individualCircles[current].SetActive(true);
    }

    public void setCurrent()
    {
        current = current + 1;
        if (current < individualCircles.Count)
        {
            individualCircles[current].SetActive(true);
        }
    }
}
