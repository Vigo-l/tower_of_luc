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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HelpCube"))
        {
            doorDoor.SetActive(false);
        }
    }
}
