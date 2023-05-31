using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class becomeGood : MonoBehaviour
{
    public Sprite goodBunny;
    private bool isGood = false;
    public goToNext flag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.layer == LayerMask.NameToLayer("Spirit"))
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer.sprite != goodBunny) {
                SoundManager.PlaySound("not_evil");
            }
            spriteRenderer.sprite = goodBunny;
            isGood = true;
            flag.bunnyCount++;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Human") && !isGood)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}