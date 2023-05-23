using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

    public GameObject player;

    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "SpiritWood")
    {
        player.layer = LayerMask.NameToLayer("Spirit");
    }
}

void OnCollisionExit2D(Collision2D collision) {
    
   DelayedTagChange();
}



 private IEnumerator DelayedTagChange()
    {
        // This line makes Unity wait for 0.5 seconds before continuing
        yield return new WaitForSeconds(1f);

        // Change the tag after the delay
        player.layer = LayerMask.NameToLayer("Human");
    }
    
}
