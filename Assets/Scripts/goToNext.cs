using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToNext : MonoBehaviour
{
    public float playerX;
    public float playerY;
    public Transform playerPosition;
    public Transform cameraPosition;


    private void OnTriggerStay2D(Collider2D collider) {
         if (collider.CompareTag("Player"))
        {
           collider.transform.position = playerPosition.position;
           Camera.main.transform.Translate(0f, -41f, 0f);
        }
    }
}


 