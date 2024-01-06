using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    public float upwardSpeed = 4f; // Increase the upward speed
    public float swayAmount = 1.5f; // Increase the sway amount
    public float swayFrequency = 1.0f; // Set the sway frequency

    void Update()
    {
        // Move the object upwards
        transform.Translate(Vector3.up * upwardSpeed * Time.deltaTime);

        // Sway the object randomly to the right or left based on the frequency
        float sway = Mathf.Sin(Time.time * swayFrequency) * swayAmount;
        transform.Translate(Vector3.right * sway * Time.deltaTime);
    }
}
