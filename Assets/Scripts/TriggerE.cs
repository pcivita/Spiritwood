using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerE : MonoBehaviour
{

     public GameObject pressE;

// private void OnTriggerStay2D(Collider2D other)
//     {
//         // Check if the collider belongs to the player
//         if (other.CompareTag("Player"))
//         {
//             pressE.SetActive(true);
//         }
//     }

    private void OnTriggerExit2D(Collider2D  other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            pressE.SetActive(false);
        }
    }

}
