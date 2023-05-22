using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformInteract : MonoBehaviour
{
    public Transform player;

    public float interactionDistance = 3f;

   public PlatformMovement platformer;

   public SpriteChanger spriteChanger;

   public GameObject playerPrefab;

   public GameObject curPlayer;

   public GameObject toggle;

   GameObject newPlayer;

    

    // Update is called once per frame
    void Update()
    {

       


        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= interactionDistance)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
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