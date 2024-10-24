using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTeleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndScene");
        }
        else if (other.gameObject.CompareTag("Pear"))
        {
            SceneManager.LoadScene("EndScene 1");
        }
    }
}
