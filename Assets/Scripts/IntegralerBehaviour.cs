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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
