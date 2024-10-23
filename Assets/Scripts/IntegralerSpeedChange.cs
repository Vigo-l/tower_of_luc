using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegralerSpeedChange : MonoBehaviour
{
    [SerializeField] GameObject integraler;
    [SerializeField] AudioSource integralerScreech;
    private IntegralerBehaviour _integralerScript;
    [SerializeField] float setSpeed;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && DataManager.escapeSequence)
        {
            integraler = GameObject.FindWithTag("Integraler");
            _integralerScript = integraler.GetComponent<IntegralerBehaviour>();

            _integralerScript.speed = setSpeed;

            integralerScreech.Play();
            Debug.Log("Integraler speed updated");
            Destroy(gameObject);
        }
    }
}
