using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFill : MonoBehaviour
{
    public Sprite[] foodSprites; // Array to hold your 4 sprites
    public AudioClip[] foodAudioClips; // Array to hold your 4 audio clips
    public float foodLevel = 100f; // Initial value for food

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        UpdateFoodLevelSprite();
    }

    void Update()
    {
        // Ensure food value stays within [0, 100] range
        foodLevel = Mathf.Clamp(foodLevel, 0f, 100f);

        UpdateFoodLevelSprite();
    }

    void UpdateFoodLevelSprite()
    {
        // Determine which sprite to use based on the food level
        if (foodLevel > 75f)
        {
            spriteRenderer.sprite = foodSprites[0]; // Use the sprite for 100 to 75
            PlayFoodAudioClip(0);
        }
        else if (foodLevel > 50f)
        {
            spriteRenderer.sprite = foodSprites[1]; // Use the sprite for 75 to 50
            PlayFoodAudioClip(1);
        }
        else if (foodLevel > 25f)
        {
            spriteRenderer.sprite = foodSprites[2]; // Use the sprite for 50 to 25
            PlayFoodAudioClip(2);
        }
        else
        {
            spriteRenderer.sprite = foodSprites[3]; // Use the sprite for 25 to 0
            PlayFoodAudioClip(3);
        }
    }

    void PlayFoodAudioClip(int index)
    {
        if (audioSource && foodAudioClips.Length > index && foodAudioClips[index] != null)
        {
            audioSource.PlayOneShot(foodAudioClips[index]);
        }
    }

}

