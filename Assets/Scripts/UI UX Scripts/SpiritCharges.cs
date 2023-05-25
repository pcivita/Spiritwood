using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritCharges : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public SpiritCollector collector;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collector = FindObjectOfType<SpiritCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = sprites[collector.charges];
    }
}
