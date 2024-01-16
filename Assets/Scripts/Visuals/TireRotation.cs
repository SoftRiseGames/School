using UnityEngine;

public class TireRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Adjust the rotation speed as needed
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RotateIfNeeded();
    }

    private void RotateIfNeeded()
    {
        Vector2 velocity = rb.velocity;

        if (velocity.magnitude > 0.1f) // You can adjust this threshold based on your movement sensitivity
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
