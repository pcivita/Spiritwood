using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;

public class PlatformInteract : MonoBehaviour
{
    public Transform player;

    public float interactionDistance = 3f;

   public PlayerController platformer;

   public SpriteChanger spriteChanger;

   public GameObject playerPrefab;

   public GameObject curPlayer;

   public GameObject toggle;

   GameObject newPlayer;


   private Renderer rend; //the renderer of the object

    private Color originalColor;

    void Start() {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {

       


        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= interactionDistance)
        {
            if (tag == "SpiritWood") {
                 rend.material.color = Color.red;
            } 
            if(Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }else {
                    rend.material.color = originalColor;
            }
    }

    void Interact()
    {
        // Implement your interaction code here
       
        // If Level: Go to level scene.
        if (tag == "Level") {
        } else if(tag == "Animal") {
        } else if(tag == "SpiritWood") {
             
            // platformer.enabled = false;
             spriteChanger.ChangeSprite();
             if (!platformer.spiritMode && !platformer.inCooldown) {
                platformer.spiritMode = true;
                curPlayer.layer = LayerMask.NameToLayer("Spirit");
                Debug.Log("" + platformer.spiritMode);
                newPlayer = Instantiate(playerPrefab, player.position, Quaternion.identity);
             }
             
            //  GameObject character = GameObject.FindGameObjectWithTag("Player");
            //  PlayerMovement playerMovement = character.GetComponent<PlayerMovement>();
            // spiritwood.enabled = false;
        }  else if (tag == "Toggle") {
            toggle.SetActive(false);
        }

    }

    public GameObject GetBody()
    {
        return newPlayer;
    }

}