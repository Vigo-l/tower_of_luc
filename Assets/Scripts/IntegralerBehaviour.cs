using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegralerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject target;
    public float speed = 1.5f;

    private void Awake()
    {
        speed = 2f;
    }

    private void Update() //chase player
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}
