using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Rigidbody objectRB;
    private Transform grabPointTransform;

    [SerializeField] private bool destroyGateOnPickup;
    [SerializeField] private GameObject gateObject;
    [SerializeField] private AudioSource gateSound;

    [SerializeField] private bool changeCubeText;
    [SerializeField] private TextMeshProUGUI cubeText;
    [SerializeField] private string dropText;
    [SerializeField] private string pickText;

    private bool destroyed;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;
        objectRB.useGravity = false;

        if (destroyGateOnPickup && !destroyed)
        {
            Destroy(gateObject);
            gateSound.Play();
            destroyed = true;
        }

        if (changeCubeText)
        {
            cubeText.text = pickText;
        }
    }

    public void Drop()
    {
        this.grabPointTransform = null;
        objectRB.useGravity = true;

        if (changeCubeText)
        {
            cubeText.text = dropText;
        }
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
