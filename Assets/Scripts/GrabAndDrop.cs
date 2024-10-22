using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
            return raycastHit.collider.gameObject;
        return null;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetMouseHoverObject(5));
    }
}
