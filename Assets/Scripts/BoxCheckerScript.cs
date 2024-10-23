using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class BoxCheckerScript : MonoBehaviour
{
    public GameObject doorDoor;
    public GameObject lockedDoor;
    public GameObject doorcamera;
    public GameObject playercamera;
    private Animation dooranimate;
    public AnimationClip dooranimation;
    public AudioSource doorSound;

    public bool playAnimation;

    public bool animationPlayed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        dooranimate = lockedDoor.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playAnimation)
        {
            if (!animationPlayed)
            {
                doorcamera.SetActive(true);


                dooranimate.Play();
                StartCoroutine(DoorANIMATION());
                animationPlayed = true;
                doorSound.Play();

            }
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
