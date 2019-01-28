using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {

    private ParticleSystem system;
    public GameObject player;

    bool function;

	void Start () {
        system = GetComponent<ParticleSystem>();
        StartCoroutine(wait());
    }

    void Update () {
        if (function == true)
        {
            float playerY = player.transform.position.y;
            float playerZ = player.transform.position.z;
            float systemX = system.transform.position.x;
            float systemY = playerY;
            float systemZ = playerZ + 40;
            system.transform.position = new Vector3(systemX, systemY, systemZ);
            system.Play();
            StartCoroutine(wait());
        }  

    }

    IEnumerator wait()
    {
        function = false;
        yield return new WaitForSeconds(20);
        function = true;
    }

    public bool getFunction()
    {
        return function;
    }
}
