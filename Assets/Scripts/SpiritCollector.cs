using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritCollector : MonoBehaviour
{

    public int charges = 0; 


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "SpiritWood") {
            Destroy(collision.gameObject);
            charges++;
            Debug.Log("got charge: " + charges);
        }
    }
}
