using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class IntegralePickup : MonoBehaviour
{
    [SerializeField] private GameObject integraler;

    [SerializeField] GameObject normalMusic;
    [SerializeField] GameObject glitchMusic;

    [SerializeField] GameObject hiddenDoor;

    [SerializeField] GameObject triggers;

    [SerializeField] GameObject runText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject[] lights = GameObject.FindGameObjectsWithTag("Light"); //turn all lights red
            foreach (GameObject l in lights)
                l.GetComponent<Light>().color = Color.red;

            integraler.SetActive(true); // spawn integraler

            DataManager.escapeSequence = true; //turn on global escapesequence value which handles a bunch of shit

            normalMusic.SetActive(false); //switch music
            glitchMusic.SetActive(true);

            runText.SetActive(true);
            
            Destroy(hiddenDoor); // destroy the light emmiting from the integrale, the integrale and open the door to the ending
            Destroy(triggers);
            Destroy(gameObject);
        }
    }
}
