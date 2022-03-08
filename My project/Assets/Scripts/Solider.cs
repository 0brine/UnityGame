using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Apply a force to this Rigidbody in direction of this GameObjects up axis
        m_Rigidbody.AddForce(0, 0, 5);
    }
}