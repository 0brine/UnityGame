using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kasserne : MonoBehaviour
{
    public GameObject Unit;
    public const float interval = 5;
    public float speed;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        countDown = interval;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime * speed;
        while (countDown < 0)
        {
            Instantiate(Unit, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            countDown = interval;
        }
    }
}
