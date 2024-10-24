using UnityEngine;

public class AppelCollider : MonoBehaviour
{

    [SerializeField] private Transform FruitSpawn;

    [SerializeField] private AudioSource correctSource;
    [SerializeField] private AudioSource failSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Appel"))
        {
            Debug.Log("appel eten");
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
