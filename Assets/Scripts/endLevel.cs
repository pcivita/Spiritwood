using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour
{
    public float playerX;
    public float playerY;
    public int bunnyCount;
    public int bunnyTotal;
    public Transform playerPosition;
    public Transform cameraPosition;
    public string levelToLoad;

    private PlatformMovement pm;


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
    private void OnTriggerStay2D(Collider2D collider)
    {
        pm = collider.GetComponent<PlatformMovement>();
        if (collider.CompareTag("Player") && bunnyCount == bunnyTotal && !pm.spiritMode)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}


