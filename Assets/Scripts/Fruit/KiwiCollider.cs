using UnityEngine;

public class KiwiCollider : MonoBehaviour
{

    [SerializeField] private Transform FruitSpawn;
    [SerializeField] private GameObject AppelCollider;

    [SerializeField] private AudioSource correctSource;
    [SerializeField] private AudioSource failSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kiwi"))
        {
            Debug.Log("Kiwi eten");
            correctSource.Play();
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            other.gameObject.transform.position = FruitSpawn.transform.position;
            failSource.Play();
        }

    }
}