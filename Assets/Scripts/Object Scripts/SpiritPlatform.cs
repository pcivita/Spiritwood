using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritPlatform : MonoBehaviour
{
    public PlatformMovement pm;
    Color color;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        // Assume the object has a SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the current color of the sprite
         color = spriteRenderer.color;

        // Set the alpha to 1 (full opacity)
        color.a = 1f;

        // Set the updated color back to the sprite
        spriteRenderer.color = color;
    }

    private void Update()
    {
        if (pm.spiritMode)
        {
            color.a = 1f;
            spriteRenderer.color = color;
        } else
        {
            color.a = 0.3f;
            spriteRenderer.color = color;
        }
    }
}
