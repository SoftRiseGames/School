using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Sprite normalSprite; // The default sprite when not hovered
    public Sprite hoverSprite;  // The sprite to be displayed when hovered

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component attached to the door GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial sprite to normalSprite
        if (spriteRenderer != null && normalSprite != null)
        {
            spriteRenderer.sprite = normalSprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer or normalSprite not assigned!");
        }
    }

    void OnMouseOver()
    {
        // Change the sprite to hoverSprite when the mouse is over the door
        if (spriteRenderer != null && hoverSprite != null)
        {
            spriteRenderer.sprite = hoverSprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer or hoverSprite not assigned!");
        }
    }

    void OnMouseExit()
    {
        // Change the sprite back to normalSprite when the mouse exits the door
        if (spriteRenderer != null && normalSprite != null)
        {
            spriteRenderer.sprite = normalSprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer or normalSprite not assigned!");
        }
    }
}
