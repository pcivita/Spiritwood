using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatformMovement : MonoBehaviour
{
    public Transform player;
    public GameObject curPlayer;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private bool isGrounded = false;
    public bool spiritMode = false;
    public bool inCooldown = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public SpriteChanger spriteChanger;



    private bool hitSomething;

    private Rigidbody2D rb;

    public string[] tagsToCheck; // Set this to the tags you want to check in the Inspector
    public float checkRadius = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if ((UnityEngine.Input.GetKeyDown(KeyCode.E))) {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);
            hitSomething = false;
            if (hitColliders != null) {
                foreach (var hitCollider in hitColliders) {
                   // Debug.Log(hitCollider.tag);
                    if (hitCollider.gameObject != this.gameObject && tagsToCheck.Contains(hitCollider.tag)) {
                        hitSomething = true;
                        //Debug.Log(hitCollider.gameObject.name);
                    //Debug.Log("Detected an object with one of the specified tags: " + hitCollider.gameObject.name);
                    // TODO: INTERACT!!!!!!
                    break;  // exit the loop as we found a valid object
                    }
                }
            }
            
            if (spiritMode && !hitSomething) {
            GameObject body = GameObject.FindGameObjectWithTag("Body");
                player.position = body.transform.position;
                curPlayer.layer = LayerMask.NameToLayer("Human");
                StartCoroutine(SetSpiritCooldown(3f));
                spriteChanger.ChangeSprite();
                spiritMode = false;
                Destroy(body);
                //StartCoroutine(SetSpiritCooldown(3f));
               // Debug.Log(body.transform.position);
                //Vector3 currentPlayerPosition = body.transform.position;
                //Debug.Log(currentPlayerPosition);
            }
        }


         
        
        



       




        float moveX = Input.GetAxis("Horizontal");

        // Moving the player
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Checking if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }


       private IEnumerator SetSpiritCooldown(float seconds) {
            inCooldown = true;
            yield return new WaitForSeconds(seconds);
            inCooldown = false;
        }


}
