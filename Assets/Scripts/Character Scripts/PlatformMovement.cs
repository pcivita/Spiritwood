using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatformMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    //bool crouch = false;



    // PEDRO VARIABLES:
    public Transform player;
    public GameObject curPlayer;
    GameObject newPlayer;
    public GameObject playerPrefab;
    public bool spiritMode = false;
    public bool inCooldown = false;
    public SpriteChanger spriteChanger;
    private SpiritCollector collector;
    private int waterLayer = 4;


    public bool movementEnabled = true;
    public bool inConversation = false;

    // INTERACT VARIABLES:
    private bool hitSomething;
    private Rigidbody2D rb;
    public string[] tagsToCheck; // Set this to the tags you want to check in the Inspector
    public float checkRadius = 1f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        collector = GetComponent<SpiritCollector>();
    }

    void Update() {
        //Debug.Log(collector.charges);
        if (UnityEngine.Input.GetKeyDown(KeyCode.E)) {

            CheckForInteraction();
            // First Check if it hit something (TODO)
            
            if (!hitSomething) {
            // Second check if in spiritMode:
            if (spiritMode) {
                    ReturnToBody();
            }

            // Third Check Charges:
            if (collector.charges != 0 && !inCooldown) {
                StartSpiritMode();
            }
            hitSomething = false;
            }
           
        }

        // Movement!
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("isJumping", true);
        }

    }

    void CheckForInteraction() {
        Debug.Log("Checking");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);
        hitSomething = false;
        if (hitColliders != null) {
                foreach (var hitCollider in hitColliders) {
                Debug.Log("collider: " + hitCollider.tag);
                    // if it hit something that it can interact with:
                    if (hitCollider.gameObject != this.gameObject && tagsToCheck.Contains(hitCollider.tag)) {
                        hitSomething = true;

                    if (hitCollider.tag == "Toggle") {
                       
                        Debug.Log("Toggle");
                        SoundManager.PlaySound("switch");
                        hitCollider.gameObject.GetComponent<PlatformInteract>().Toggle();
                        
                        
                    // TODO: INTERACT!!!!!
                    } else if (hitCollider.tag == "Animal" && !inConversation) {
                        PlatformDialogueTrigger dialogueTrigger = hitCollider.gameObject.GetComponent<PlatformDialogueTrigger>();
                        Debug.Log("Talk to turtle");
                        dialogueTrigger.TriggerDialogue();
                    }
                    Debug.Log(hitCollider.tag);
                    break;  // exit the loop as we found a valid object
                    }
                }
            }
    }
    
    void StartSpiritMode() {
        // consume a charge:
        collector.charges--;
        Debug.Log("Consume " + collector.charges);
        // go into spiritmode:
        // TODO: MAKE SPIRIT ANIMATIONS
        SoundManager.PlaySound("release_spirit");
        spiritMode = true;
        animator.SetBool("spiritmode", true);
        controller.m_WhatIsGround &= ~(1 << waterLayer); 
        curPlayer.layer = LayerMask.NameToLayer("Spirit");
        newPlayer = Instantiate(playerPrefab, player.position, Quaternion.identity);
    }


    void ReturnToBody() {
        //TODO: RETURN TO NON SPIRIT ANIMATIONS
        SoundManager.PlaySound("back_to_body");
        GameObject body = GameObject.FindGameObjectWithTag("Body");
        player.position = body.transform.position;
        curPlayer.layer = LayerMask.NameToLayer("Human");
        StartCoroutine(SetSpiritCooldown(0.5f));
        controller.m_WhatIsGround |= (1 << waterLayer);
        spiritMode = false;
        animator.SetBool("spiritmode", false);
        Destroy(body);
    }

    private IEnumerator SetSpiritCooldown(float seconds) {
            inCooldown = true;
            // TODO: SET COLOR.
            yield return new WaitForSeconds(seconds);
            inCooldown = false;
        }

    


    public void OnLanding() {
        animator.SetBool("isJumping", false);
    }
    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}
