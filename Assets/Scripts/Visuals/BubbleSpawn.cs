using System.Collections;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public int numberOfPrefabsToSpawn = 1; // Default to 1
    public Collider2D spawnArea;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;
    public float spawnChance = 0.1f; // Adjust this to control the rarity of multiple spawns

    void Start()
    {
        if (spawnArea == null)
        {
            Debug.LogError("Spawn area collider is not assigned.");
            return;
        }

        StartCoroutine(SpawnPrefabsRandomly());
    }

    IEnumerator SpawnPrefabsRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            // Randomly decide to spawn multiple bubbles
            if (Random.value < spawnChance)
            {
                numberOfPrefabsToSpawn = Random.Range(2, 4); // Spawn 2-5 bubbles
            }
            else
            {
                numberOfPrefabsToSpawn = 1; // Spawn only 1 bubble
            }

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
}
