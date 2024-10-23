using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class IntegralePickup : MonoBehaviour
{
    [SerializeField] private GameObject integraler;
    [SerializeField] private GameObject integraleLight;

    [SerializeField] GameObject normalMusic;
    [SerializeField] GameObject glitchMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
            foreach (GameObject l in lights)
                l.GetComponent<Light>().color = Color.red;

            integraler.SetActive(true);

            DataManager.escapeSequence = true;

            normalMusic.SetActive(false);
            glitchMusic.SetActive(true);

            Destroy(integraleLight);
            Destroy(gameObject);
        }
    }
}
