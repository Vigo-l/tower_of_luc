using UnityEngine;

public class BoxCheckerScript : MonoBehaviour
{
    public GameObject doorDoor;
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
        if (other.gameObject.CompareTag("HelpCube"))
        {
            doorDoor.SetActive(false);
        }
    }
}
