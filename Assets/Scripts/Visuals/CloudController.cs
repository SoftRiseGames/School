using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float moveSpeedMin = 5f;
    public float moveSpeedMax = 15f;
    public float fadeInTimeMin = 1f;
    private float fadeOutTime; // Declare fadeOutTime outside of Start
    private float fadeInTime; // Declare fadeOutTime outside of Start
    public float fadeInTimeMax = 3f;
    public float fadeOutTimeMin = 2f;
    public float fadeOutTimeMax = 4f;
    public float fullOpacityDuration = 1f; // New parameter for pause at full opacity

    private Rigidbody2D rb2d;
    private float startTime;
    private float fadeInCompleteTime; // Time when fade-in finishes

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Randomize movement speed (always moving left)
        float moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
        rb2d.velocity = new Vector2(-moveSpeed, 0); // Set velocity directly to the left

        // Randomize fade times
        fadeInTime = Random.Range(fadeInTimeMin, fadeInTimeMax);
        fadeOutTime = Random.Range(fadeOutTimeMin, fadeOutTimeMax);
        startTime = Time.time;
        fadeInCompleteTime = startTime + fadeInTime;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float fadeProgress = Mathf.Clamp01(elapsedTime / (fadeInTime + fadeOutTime + fullOpacityDuration));

        // Opacity animation with pause at full opacity
        if (fadeProgress < 0.5f)
        {
            float opacity = fadeProgress * 2f;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
        }
        else if (fadeProgress < 0.75f) // Pause at full opacity
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            float opacity = 1f - (fadeProgress - 0.75f) * 4f; // Fade out after pause
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
        }

        // Destroy at the end of fade out
        if (fadeProgress >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
