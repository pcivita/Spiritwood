using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    private bool hitSomething;
    public float checkRadius = 1f;
    public string[] tagsToCheck; // Set this to the tags you want to check in the Inspector

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

     

        if (UnityEngine.Input.GetKeyDown(KeyCode.E)) {
            CheckForInteraction();
        }
        

        // Get the horizontal and vertical input (which will be -1, 0, or 1)
        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Hspeed", (movement.x));
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vspeed", (movement.y));

        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        // Move the character
        if (movementEnabled) {
         rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
       
    }


        void CheckForInteraction() {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);
        hitSomething = false;
        if (hitColliders != null) {
                foreach (var hitCollider in hitColliders) {
                    // if it hit something that it can interact with:
                    if (hitCollider.gameObject != this.gameObject && tagsToCheck.Contains(hitCollider.tag)) {
                        hitSomething = true;

                    if (hitCollider.tag == "Toggle") {
                       
                        Debug.Log("Toggle");
                        hitCollider.gameObject.GetComponent<PlatformInteract>().Toggle();
                        
                        
                    // TODO: INTERACT!!!!!
                    } else if (hitCollider.tag == "Animal" && !inConversation) {
                        Debug.Log("Toggle");
                        DialogueTrigger dialogueTrigger = hitCollider.gameObject.GetComponent<DialogueTrigger>();
                        TriggerE eTrigger = hitCollider.gameObject.GetComponent<TriggerE>();
                        eTrigger.pressE.SetActive(false);
                        dialogueTrigger.TriggerDialogue();
                    }
                    break;  // exit the loop as we found a valid object
                    }
                }
            }
    }


}
