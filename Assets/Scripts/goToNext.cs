using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToNext : MonoBehaviour
{
    public float playerX;
    public float playerY;
    public int bunnyCount;
    public int bunnyTotal;
    public Transform playerPosition;
    public Transform cameraPosition;


    Color color;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        // Assume the object has a SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the current color of the sprite
        color = spriteRenderer.color;

        // Set the alpha to 1 (full opacity)
        color.a = 0.2f;

        // Set the updated color back to the sprite
        spriteRenderer.color = color;

    }


    private void Update()
    {
        if (bunnyCount == bunnyTotal)
        {
            // Set the alpha to 1 (full opacity)
            color.a = 1f;

            // Set the updated color back to the sprite
            spriteRenderer.color = color;
        }
    }
    private void OnTriggerStay2D(Collider2D collider) {
         if (collider.CompareTag("Player") && bunnyCount == bunnyTotal)
        {
           collider.transform.position = playerPosition.position;
           Camera.main.transform.Translate(0f, -41f, 0f);
        }
    }
}


 