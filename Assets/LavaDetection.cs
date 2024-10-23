using UnityEngine;

public class LavaDetection : MonoBehaviour
{

    [SerializeField] private GameObject RespawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("HelpCube"))
        {
            other.gameObject.transform.position = RespawnPoint.transform.position;
            other.gameObject.transform.rotation = RespawnPoint.transform.rotation;
        }
    }
}
