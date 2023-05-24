using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public bool inConversation = false;
    
    public bool movementEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject this script is attached to
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical input (which will be -1, 0, or 1)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        // Move the character
        if (movementEnabled) {
         rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
       
    }
}
