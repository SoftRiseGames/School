using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFill : MonoBehaviour
{
    // Public variable to control the water level (0 to 100)
    public float waterLevel = 100f;

    // The minimum y-position relative to the parent for the water
    public float minYRelative = -2f;

    // The maximum y-position relative to the parent for the water
    public float maxYRelative = 0.7f;

    // The speed at which the water level changes
    public float fillSpeed = 1;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (PlayerPrefs.HasKey("waterLevel"))
            waterLevel = PlayerPrefs.GetFloat("waterLevel");
        else
            waterLevel = 0;

        waterLevel = Mathf.Clamp(waterLevel, 0f, 100f);

        // Calculate the target y-position based on the water level
        float targetY = Mathf.Lerp(minYRelative, maxYRelative, waterLevel / 100f);

        // Set the position directly without any interpolation
        transform.localPosition = new Vector3(transform.localPosition.x, targetY, transform.localPosition.z);
    }

    void Update()
    {
        // Clamp the water level between 0 and 100
        waterLevel = Mathf.Clamp(waterLevel, 0f, 100f);

        // Calculate the target y-position based on the water level
        float targetY = Mathf.Lerp(minYRelative, maxYRelative, waterLevel / 100f);

        // Move the water towards the target position
        float newY = Mathf.MoveTowards(transform.localPosition.y, targetY, fillSpeed * Time.deltaTime);

        // Update the local position of the water GameObject
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}
