using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // Array of prefabs to spawn
    public float spawnInterval = 2f; // Time between spawns
    public Vector2 spawnRangeX = new Vector2(-10f, 10f); // Custom X range for spawning
    public Vector2 spawnRangeY = new Vector2(-5f, 5f); // Custom Y range for spawning

    private void Start()
    {
        // Invoke the SpawnPrefab method repeatedly with the specified interval
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    private void SpawnPrefab()
    {
        // Calculate random spawn position within the custom range
        float spawnPosX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float spawnPosY = Random.Range(spawnRangeY.x, spawnRangeY.y);

        // Select a random prefab from the array
        GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

        // Instantiate the selected prefab at the random position
        GameObject spawnedObject = Instantiate(randomPrefab, new Vector3(spawnPosX, spawnPosY, 0f), Quaternion.identity);

        // Get the global position of the spawned object
        Vector3 globalPosition = spawnedObject.transform.position;

        // Do something with the global position (e.g., print it)
        
    }
}
