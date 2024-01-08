using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFill : MonoBehaviour
{
    // Public variable to control the water level (0 to 100)
    public float waterLevel = 100f;

    // The minimum y-position for the water
    public float minY = -2f;

    // The maximum y-position for the water
    public float maxY = 0.7f;

    // The speed at which the water level changes
    public float fillSpeed = 1;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Clamp the water level between 0 and 100
        waterLevel = Mathf.Clamp(waterLevel, 0f, 100f);

        // Calculate the target y-position based on the water level
        float targetY = Mathf.Lerp(minY, maxY, waterLevel / 100f);

        // Move the water towards the target position
        float newY = Mathf.MoveTowards(transform.position.y, targetY, fillSpeed * Time.deltaTime);

        // Update the position of the water GameObject
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
}