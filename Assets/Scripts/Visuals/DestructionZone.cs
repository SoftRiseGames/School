using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a Rigidbody2D component
        Rigidbody2D rb2D = collision.collider.GetComponent<Rigidbody2D>();

        if (rb2D != null)
        {
            // Destroy the GameObject that collides with the zone
            Destroy(collision.gameObject);
        }
    }
}
