using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class becomeGood : MonoBehaviour
{
   public Sprite goodBunny;
    private bool isGood = false;

private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
          if (other.gameObject.layer == LayerMask.NameToLayer("Spirit"))
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
             spriteRenderer.sprite = goodBunny;
            isGood = true;
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Human") && !isGood)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
