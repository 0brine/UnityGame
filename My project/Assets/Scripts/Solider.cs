using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 1;


    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //rigidbody.velocity = Vector3.forward * 1;
    }

    void FixedUpdate()
    {
        Vector3 toTarget = target.position - transform.position;
        toTarget.y = 0;


        if (toTarget.magnitude < 0.1)
        {
            toTarget = Vector3.zero;
        }

        Vector3 movement = toTarget.normalized * speed;
        movement.y = rigidbody.velocity.y;

        rigidbody.velocity = movement;
    }
}
