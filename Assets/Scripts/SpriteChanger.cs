using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class SpriteChanger : MonoBehaviour
{
    public Sprite spiritSprite;
    public Sprite humanSprite;
    private PlayerController pm;

    void Start () {
         pm = GetComponent<PlayerController>();;
    }

    public void ChangeSprite()
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (!pm.spiritMode && !pm.inCooldown)
        {
            spriteRenderer.sprite = spiritSprite;
        } else {
            Debug.Log("HUMAN!");
             spriteRenderer.sprite = humanSprite;
        }
    }
}

