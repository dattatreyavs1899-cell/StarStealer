using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public EnemyAI enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.StartChasing(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.StopChasing();
        }
    }
}