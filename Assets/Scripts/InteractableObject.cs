using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public Transform player;
    
    public string sceneName;
    public float interactionDistance = 3f;

    public TopDownMovement playerMovement;

    

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= interactionDistance)
        {
            if(Input.GetKeyDown(KeyCode.E) && !playerMovement.inConversation)
            {
                Debug.Log("Interacts");
                Interact();
            }
        }
    }

    void Interact()
    {
        // Implement your interaction code here
       
        // If Level: Go to level scene.
        if (tag == "Level") {
            SceneManager.LoadScene(sceneName);
        } else if(tag == "Animal") {
            Debug.Log("ANIMALLLL " + gameObject.name);
            DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
            // Call the TriggerDialogue function
            dialogueTrigger.TriggerDialogue();
        } else if(tag == "SpiritWood") {
             Debug.Log("SPIRIT");
             //platformer.enabled = false;
            //  GameObject character = GameObject.FindGameObjectWithTag("Player");
            //  PlayerMovement playerMovement = character.GetComponent<PlayerMovement>();
            // spiritwood.enabled = false;
        }
 

    }

    // To visualize the interaction distance in the Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}