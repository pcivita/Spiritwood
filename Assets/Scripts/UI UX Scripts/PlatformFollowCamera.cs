using System;
//using TarodevController;
using UnityEngine;

public class PlatformFollowCamera : MonoBehaviour {
   // [SerializeField] private float height;

public Transform _player; // Assign your player in the inspector

private bool hasPassedThreshold = false;

private void Update()
{
    // If the player has passed the threshold, adjust the camera's Y position to match the player's
    if (hasPassedThreshold)
    {
        transform.position = new Vector3(transform.position.x, 5, transform.position.z);
    }
}

// This function is called when something enters the trigger
private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Trigger")) // If the collided object has the "TriggerZone" tag
    {
        Debug.Log("YO");
        hasPassedThreshold = true;
    }
}

// This function is called when something exits the trigger
private void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("Trigger")) // If the collided object has the "TriggerZone" tag
    {
        hasPassedThreshold = false;
    }
}
}