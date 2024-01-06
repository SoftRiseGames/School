using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxMultiplierX = 0.2f; // Adjust this value for the desired X-axis multiplier
    public float parallaxMultiplierY = 0.1f; // Adjust this value for the desired Y-axis multiplier
    public float maxOffsetX = 5f;
    public float maxOffsetY = 3f;
    public float smoothSpeed = 5f; // Adjust this value for the desired smoothness

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {
        ParallaxRotation();
    }
    void ParallaxRotation()
    {
        // Get the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the parallax offset based on the mouse position
        float parallaxOffsetX = (initialPosition.x - mousePosition.x) * parallaxMultiplierX;
        float parallaxOffsetY = (initialPosition.y - mousePosition.y) * parallaxMultiplierY;

        // Clamp the parallax offset within the specified limits
        parallaxOffsetX = Mathf.Clamp(parallaxOffsetX, -maxOffsetX, maxOffsetX);
        parallaxOffsetY = Mathf.Clamp(parallaxOffsetY, -maxOffsetY, maxOffsetY);

        // Calculate the target position
        Vector3 targetPosition = new Vector3(initialPosition.x + parallaxOffsetX, initialPosition.y + parallaxOffsetY, transform.position.z);

        // Smoothly interpolate between the current position and the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
