using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class VisualAnimator : MonoBehaviour
{
    public PlayerController controller;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool jumped;


     private void Start()
    {
        controller = GetComponentInParent<PlayerController>();
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {

        
        // Landed on the Ground
            if (!controller._grounded && controller._groundHitCount > 0) {
                animator.SetBool("isJumping", controller.left);
            }
            // Left the Ground
            else if (!controller._grounded && controller._groundHitCount == 0) {
               animator.SetBool("isJumping", controller.left);
            }
        
    
        animator.SetFloat("Speed", controller._speed.x);
        if (controller._speed.x > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false; // moving right
        }
        else if (controller._speed.x < 0 && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true; // moving left
        }
    }
    
}



    

