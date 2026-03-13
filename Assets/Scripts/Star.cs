using UnityEngine;

public class Star : MonoBehaviour
{
    public StarSpawner spawner;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(1);

            spawner.RemoveStar(gameObject);
            spawner.SpawnNewStar();

            Destroy(gameObject);
        }
    }
}