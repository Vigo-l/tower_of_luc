using UnityEngine;

public class ButtonInteract : Interactable
{
    public GameObject lockedDoor;
    public override void OnFocus()
    {
        Debug.Log("meneer focus");
    }

    public override void OnInteract()
    {
        lockedDoor.SetActive(false);
    }

    public override void OnLoseFocus()
    {

    }
}
