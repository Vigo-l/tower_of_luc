using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleJumpscare : MonoBehaviour
{
    [SerializeField] private GameObject jumpscareText;
    [SerializeField] private AudioSource jumpscareAudio;
    private bool hasBeenTriggered = false;
    public bool removeText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(hasBeenTriggered);
            if (!hasBeenTriggered && !removeText)
            {
                jumpscareText.SetActive(true);
                jumpscareAudio.Play();
                hasBeenTriggered = true;

            }
            else
            {
                jumpscareText.SetActive(false);
            }

            if(removeText)
                jumpscareText.SetActive(false);
        }
    }
}
