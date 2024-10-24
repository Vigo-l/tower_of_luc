using System.Collections;
using UnityEngine;

public class Sinaasappel : MonoBehaviour
{
    public GameObject lockedDoor;
    public GameObject doorcamera;
    public GameObject playercamera;
    public Animation dooranimate;
    public AnimationClip dooranimation;
    public AudioSource doorSound;

    [SerializeField] private AudioSource correctSource;
    [SerializeField] private AudioSource failSource;


    private bool hasBeenTriggered = false;


    [SerializeField] private Transform FruitSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sinaasappel"))
        {
            Debug.Log("Sinaasappel eten");
            correctSource.Play();
            other.gameObject.SetActive(false);
            if (!hasBeenTriggered)
            {
                doorcamera.SetActive(true);


                dooranimate.Play();
                doorSound.Play();
                StartCoroutine(DoorANIMATION());
            }
            else
            {
                return;
            }


        }
        else
        {

            other.gameObject.transform.position = FruitSpawn.transform.position;
            failSource.Play();
        }

    }
    IEnumerator DoorANIMATION()
    {
        yield return new WaitForSeconds(dooranimation.length);
        doorcamera.SetActive(false);
        gameObject.SetActive(false);


    }
}