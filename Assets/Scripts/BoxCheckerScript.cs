using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class BoxCheckerScript : MonoBehaviour
{
    public GameObject doorDoor;
    public GameObject lockedDoor;
    public GameObject doorcamera;
    public GameObject playercamera;
    public Animation dooranimate;
    public AnimationClip dooranimation;

    public bool playAnimation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (playAnimation)
        {
            doorcamera.SetActive(true);


            dooranimate.Play();
            StartCoroutine(DoorANIMATION());
        }
        else
        {
            if (other.gameObject.CompareTag("HelpCube"))
            {
                doorDoor.SetActive(false);
            }
        }
    }

    IEnumerator DoorANIMATION()
    {
        yield return new WaitForSeconds(dooranimation.length);
        doorcamera.SetActive(false);
    }
}
