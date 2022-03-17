using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField]
    private int ammountToDestroy = 10;

    public int Destroyers = 0;

    private void FixedUpdate()
    {
        if (Destroyers >= ammountToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
