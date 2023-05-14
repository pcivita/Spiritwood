using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;

public class PlatformInteract : MonoBehaviour
{
    public Transform player;

    public float interactionDistance = 3f;

   public PlayerMovement platformer;

   public SpriteChanger spriteChanger;

   public GameObject playerPrefab;

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
            Debug.Log("ANIMALLLL " + gameObject.name);
        } else if(tag == "SpiritWood") {
             
            // platformer.enabled = false;
             spriteChanger.ChangeSprite();
             if (!platformer.spiritMode && !platformer.inCooldown) {
                platformer.spiritMode = true;
                Debug.Log("FUUUUUUCK" + platformer.spiritMode);
                newPlayer = Instantiate(playerPrefab, player.position, Quaternion.identity);
             }
             
            //  GameObject character = GameObject.FindGameObjectWithTag("Player");
            //  PlayerMovement playerMovement = character.GetComponent<PlayerMovement>();
            // spiritwood.enabled = false;
        }

    }

    public GameObject GetBody()
    {
        return newPlayer;
    }

}