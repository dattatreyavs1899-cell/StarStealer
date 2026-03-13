using UnityEngine;
using System.Collections.Generic;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public BoxCollider2D spawnArea;

    public float minStarDistance = 1.5f;
    public int maxStars = 5;

    private List<GameObject> activeStars = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < maxStars; i++)
        {
            SpawnNewStar();
        }
    }

    public void SpawnNewStar()
    {
        
        activeStars.RemoveAll(star => star == null);

        Bounds bounds = spawnArea.bounds;
        float margin = 0.5f;

        Vector2 spawnPosition = Vector2.zero;
        bool validPosition = false;

        int attempts = 0;

        while (!validPosition && attempts < 30)
        {
            float x = Random.Range(bounds.min.x + margin, bounds.max.x - margin);
            float y = Random.Range(bounds.min.y + margin, bounds.max.y - margin);

            spawnPosition = new Vector2(x, y);
            validPosition = true;

            foreach (GameObject existingStar in activeStars)
            {
                if (existingStar != null &&
                    Vector2.Distance(spawnPosition, existingStar.transform.position) < minStarDistance)
                {
                    validPosition = false;
                    break;
                }
            }

            attempts++;
        }

        GameObject newStar = Instantiate(starPrefab, spawnPosition, Quaternion.identity);

        Star starScript = newStar.GetComponent<Star>();
        starScript.spawner = this;

        activeStars.Add(newStar);
    }

    public void RemoveStar(GameObject star)
    {
        if (activeStars.Contains(star))
        {
            activeStars.Remove(star);
        }
    }
}