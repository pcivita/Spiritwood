using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlatformLever : MonoBehaviour
{
    public PlatformMovement pm; 
    Color color;
    public SpriteRenderer spriteRenderer;
    //public GameObject sPlatform;
    // public GameObject hPlatform;
    public Animator animator;
    public Animator leverAnimator;
    SpiritPlatform platformScript;
    private bool right = true;

    public List<GameObject> SpiritPlatforms = new List<GameObject>();
    public List<GameObject> HumanPlatforms = new List<GameObject>();
    
        void Start() {
            // Assume the object has a SpriteRenderer component
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Get the current color of the sprite
             color = spriteRenderer.color;

            // Set the alpha to 1 (full opacity)
            color.a = 1f;

            // Set the updated color back to the sprite
            spriteRenderer.color = color;
            //platformScript = sPlatform.GetComponent<SpiritPlatform>();
    

        
    
    }

    public void changeState()
    {
         foreach (GameObject sPlatform in SpiritPlatforms)
        {
            if (right) {
                 sPlatform.SetActive(true);
            } else {
            sPlatform.SetActive(false);
            }

        }

        foreach (GameObject hPlatform in HumanPlatforms)
        {
            if (right) {
                  hPlatform.SetActive(false);
            } else {
                hPlatform.SetActive(true);
            }
        }

        leverAnimator.SetBool("toggled", right);

         right = !right;
    }


        private void Update()
     {
        if (pm.spiritMode)
        {
            color.a = 0.3f;
            spriteRenderer.color = color;
        }
        else
        {
            color.a = 1f;
            spriteRenderer.color = color;
        }
     }

}
