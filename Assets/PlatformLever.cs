using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLever : MonoBehaviour
{
    public PlatformMovement pm; 
    Color color;
    public SpriteRenderer spriteRenderer;
    public GameObject sPlatform;
    public GameObject hPlatform;
    public Animator animator;
    public Animator leverAnimator;
    SpiritPlatform platformScript;
    private bool right = true;
    
        void Start() {
        animator = sPlatform.GetComponent<Animator>();
     
        // Assume the object has a SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the current color of the sprite
        color = spriteRenderer.color;

        // Set the alpha to 1 (full opacity)
        color.a = 1f;

        // Set the updated color back to the sprite
        spriteRenderer.color = color;
        platformScript = sPlatform.GetComponent<SpiritPlatform>();
    
    }

    public void changeState()
    {
        Debug.Log(right);
        if (right) {
            sPlatform.SetActive(false);
            hPlatform.SetActive(true);

            // platformScript.alwaysOn = true;
            // sPlatform.layer = LayerMask.NameToLayer("Ground");
            // animator.SetBool("alwaysOn", true);
            leverAnimator.SetBool("toggled", true);
        } else {
            sPlatform.SetActive(true);
            hPlatform.SetActive(false);

            // platformScript.alwaysOn = true;
            // sPlatform.layer = LayerMask.NameToLayer("Ground");
            // animator.SetBool("alwaysOn", true);
            leverAnimator.SetBool("toggled", false);
        }
        
        right = !right;

    }

        private void Update()
    {
        if (platformScript.alwaysOn) {
            color.a = 1f;
            spriteRenderer.color = color;
        } else if (pm.spiritMode)
        {
            color.a = 1f;
            spriteRenderer.color = color;
        }
        else
        {
            color.a = 0.3f;
            spriteRenderer.color = color;
        }
    }

}
