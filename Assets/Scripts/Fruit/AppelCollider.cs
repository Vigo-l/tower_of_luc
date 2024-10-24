using UnityEngine;

public class AppelCollider : MonoBehaviour
{

    [SerializeField] private Transform FruitSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Appel"))
        {
            Debug.Log("appel eten");
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);

        }
        else
        {
            other.gameObject.transform.position = FruitSpawn.transform.position;
        }

    }
}
