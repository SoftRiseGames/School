using UnityEngine;

public class VibrationMovement : MonoBehaviour
{
    public float amplitudeminX = 0.1f;
    public float amplitudemaxX = 0.1f;
    public float amplitudeminY = 0.1f;
    public float amplitudemaxY = 0.1f;
    public float frequency = 2.0f;

    private Vector2 initialPosition;
    private Vector2 originalPosition;

    void Start()
    {
        initialPosition = transform.position;
        originalPosition = transform.position;
    }

    void Update()
    {
        // Regular movement
        // Use your own movement logic here, this is just a simple example
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        transform.Translate(movement * Time.deltaTime);

        // Vibration
        float displacementX = Mathf.Lerp(amplitudeminX, amplitudemaxX, Mathf.Sin(frequency * Time.time));
        float displacementY = Mathf.Lerp(amplitudeminY, amplitudemaxY, Mathf.Sin(frequency * Time.time));
        Vector2 vibration = new Vector2(displacementX, displacementY);
        Vector2 newPosition = originalPosition + vibration;

        // Apply the new position to the object
        transform.position = newPosition;
    }
}
