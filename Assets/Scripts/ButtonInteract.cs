using System.Collections;
using UnityEngine;

public class ButtonInteract : Interactable
{
    public GameObject lockedDoor;
    public GameObject doorcamera;
    public GameObject playercamera;
    public Animation dooranimate;
    public AnimationClip dooranimation;
    public override void OnFocus()
    {
        Debug.Log("meneer focus");
    }

    public override void OnInteract()
    {
        doorcamera.SetActive(true);


        dooranimate.Play();
        StartCoroutine(DoorANIMATION());


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
