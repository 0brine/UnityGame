using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeToUseAsHitbox;

    void Start()
    {
        BoxCollider hitbox = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;

        hitbox.center = cubeToUseAsHitbox.transform.localPosition;
        hitbox.size = cubeToUseAsHitbox.transform.localScale;

        BoxCollider oldHitbox = cubeToUseAsHitbox.GetComponent<BoxCollider>();
        if (oldHitbox != null)
            oldHitbox.enabled = false;
    }
}
