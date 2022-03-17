using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] allGameObjects = GameObject.FindGameObjectsWithTag("Movable");

        foreach (GameObject gameObject in allGameObjects)
        {
            if (gameObject.transform.position.magnitude > 1000)
            {
                Destroy(gameObject);
            }
        }
    }
}
