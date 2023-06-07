using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritCharges : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public SpiritCollector collector;
    public MoveUpAndDown movement;
    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        collector = FindObjectOfType<SpiritCollector>();
        movement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        spriteRenderer.sprite = sprites[collector.charges];

        // If collector charges are not equal to zero, enable MoveUpAndDown
        if (collector.charges != 0) 
        {
            movement.enabled = true;
        }
        else // If collector charges are equal to zero, disable MoveUpAndDown
        {
            movement.enabled = false;
        }
        
    }
}
