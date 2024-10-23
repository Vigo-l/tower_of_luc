using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Rigidbody objectRB;
    private Transform grabPointTransform;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;
        objectRB.useGravity = false;
    }

    public void Drop()
    {
        this.grabPointTransform = null;
        objectRB.useGravity = true;
    }

    private void FixedUpdate()
    {
        if(grabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, grabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRB.MovePosition(grabPointTransform.position);
        }
    }
}
