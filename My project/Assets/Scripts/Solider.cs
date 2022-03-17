using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;


    private Rigidbody rigidbody;
    private CapsuleCollider collider;

    private Vector3 target;
    private GameObject objectInTheWay;

    public GameObject ObjectInTheWay
    {
        get { return objectInTheWay; }
        set
        {
            if (objectInTheWay == value)
                return;

            Destroyable oldDestroyable = objectInTheWay?.GetComponent<Destroyable>();
            Destroyable newDestroyable = value?.GetComponent<Destroyable>();

            if (oldDestroyable != null)
            {
                oldDestroyable.Destroyers--;
            }

            if (newDestroyable != null)
            {
                newDestroyable.Destroyers++;
            }

            objectInTheWay = value;
        }
    }

    private void Start()
    {

        target.x = Mathf.Floor(transform.position.x) + 0.5f;
        target.y = 0.1f;
        target.z = Mathf.Floor(transform.position.z) + 1.5f;


        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        //rigidbody.velocity = Vector3.forward * 1;
    }

    private void FixedUpdate()
    {
        TurnTowardsTarget();
        MoveForward();
        HandleObjectsInTheWay();
    }

    private void MoveForward()
    {
        Vector3 targetDirection = target - transform.position;
        targetDirection.y = 0;

        if (targetDirection.magnitude < 0.5)
        {
            target.z += 1;
        }

        Vector3 movement = Vector3.forward * speed;
        movement.y = rigidbody.velocity.y;
        rigidbody.velocity = movement;
    }

    private void HandleObjectsInTheWay()
    {
        Vector3 forward = transform.forward;
        Vector3 slightlyLeft = Quaternion.Euler(0, -20, 0) * transform.forward;
        Vector3 slightlyRight = Quaternion.Euler(0, 20, 0) * transform.forward;

        RaycastHit raycastHit;
        RaycastHit raycastHit1;
        RaycastHit raycastHit2;

        Physics.Raycast(transform.position, slightlyLeft, out raycastHit1, collider.radius * transform.localScale.z + 0.2f);
        Physics.Raycast(transform.position, forward, out raycastHit, collider.radius * transform.localScale.z + 0.2f);
        Physics.Raycast(transform.position, slightlyRight, out raycastHit2, collider.radius * transform.localScale.z + 0.2f);

        Debug.DrawRay(transform.position, slightlyLeft * collider.radius * (transform.localScale.z + 0.2f), Color.blue);
        Debug.DrawRay(transform.position, forward * collider.radius * (transform.localScale.z + 0.2f), Color.blue);
        Debug.DrawRay(transform.position, slightlyRight * collider.radius * (transform.localScale.z + 0.2f), Color.blue);

        GameObject objectHit = null;
        objectHit ??= raycastHit.transform?.gameObject;
        objectHit ??= raycastHit1.transform?.gameObject;
        objectHit ??= raycastHit2.transform?.gameObject;

        if (objectHit == null)
        {
            ObjectInTheWay = null;
            return;
        }

        Solider solider = objectHit.GetComponent<Solider>();
        if (solider != null)
        {
            ObjectInTheWay = solider.ObjectInTheWay;
            return;
        }

        ObjectInTheWay = objectHit;
    }

    private void TurnTowardsTarget()
    {
        Vector3 targetDirection = target - transform.position;
        targetDirection.y = 0;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 2 * Mathf.PI, 0.0f);
        // Draw a ray pointing at our target in
        //Debug.DrawRay(transform.position, newDirection, Color.blue);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
