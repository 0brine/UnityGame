using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int moneyGeneration;
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
            PlayerStats.Money += moneyGeneration;
            countDown = interval;

            Debug.Log(PlayerStats.Money);
        }
    }
}
