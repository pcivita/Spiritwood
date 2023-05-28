using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class becomeGood : MonoBehaviour
{
   public Sprite goodBunny;

private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
          if (other.gameObject.layer == LayerMask.NameToLayer("Spirit"))
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
             spriteRenderer.sprite = goodBunny;
        }
    }
}
