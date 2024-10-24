using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntegralerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject target;
    public float speed = 3f;

    private void Awake()
    {
        speed = 3f;
    }

    private void Update() //chase player
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided with player");
            SceneManager.LoadScene("DeathScene");
        }
    }
}
