using UnityEngine;

public class BubbleSpawnController : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public int numberOfPrefabsToSpawn = 10;
    public Collider2D spawnArea;

    void Start()
    {
        if (spawnArea == null)
        {
            Debug.LogError("Spawn area collider is not assigned.");
            return;
        }

        SpawnPrefabsRandomly();
    }

    void SpawnPrefabsRandomly()
    {
        for (int i = 0; i < numberOfPrefabsToSpawn; i++)
        {
            // Generate a random position within the collider bounds
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y)
            );

            // Choose a random prefab from the array
            GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

            // Instantiate the prefab at the random position as a child of the current GameObject
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
            spawnedPrefab.transform.parent = transform;
        }
    }
}