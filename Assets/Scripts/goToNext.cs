using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToNext : MonoBehaviour
{
    public int bunnyCount;
    public int bunnyTotal;
    public Transform playerPosition;
    public Transform cameraPosition;

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
        color.a = 0.2f;

        // Set the updated color back to the sprite
        spriteRenderer.color = color;
    }


    private void Update()
    {
        pm = this.GetComponent<PlatformMovement>();
        if (bunnyCount == bunnyTotal)
        {
            // Set the alpha to 1 (full opacity)
            color.a = 1f;

            // Set the updated color back to the sprite
            spriteRenderer.color = color;
                }
    }
    private void OnTriggerStay2D(Collider2D collider) {
        pm = collider.GetComponent<PlatformMovement>();
        if (collider.CompareTag("Player") && bunnyCount == bunnyTotal && !pm.spiritMode)
        {
           collider.transform.position = playerPosition.position;
            Camera.main.transform.position = cameraPosition.position;
        }
    }
}


 