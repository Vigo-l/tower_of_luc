using UnityEngine;

public class KiwiCollider : MonoBehaviour
{

    [SerializeField] private Transform FruitSpawn;
    [SerializeField] private GameObject AppelCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kiwi"))
        {
            Debug.Log("Kiwi eten");
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            other.gameObject.transform.position = FruitSpawn.transform.position;
        }

    }
}