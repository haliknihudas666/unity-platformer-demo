using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // LateUpdate is called every after frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
