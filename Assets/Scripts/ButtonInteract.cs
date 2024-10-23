using System.Collections;
using UnityEngine;

public class ButtonInteract : Interactable
{
    public GameObject lockedDoor;
    public GameObject doorcamera;
    public GameObject playercamera;
    public Animation dooranimate;
    public AnimationClip dooranimation;
    public AudioSource doorSound;

    private bool hasBeenTriggered = false;

    public override void OnFocus()
    {
        Debug.Log("meneer focus");
    }

    public override void OnInteract()
    {
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

    IEnumerator DoorANIMATION()
    {
        yield return new WaitForSeconds(dooranimation.length);
        doorcamera.SetActive(false);


    }

    public override void OnLoseFocus()
    {

    }
}
