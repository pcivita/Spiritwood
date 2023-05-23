using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Transform _player;
    public Transform _camera; // Reference to your Camera
    public float cameraChange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the player
        if (other.gameObject.name =="Player")
        {
            Debug.Log("HIT");
            // If the player enters the trigger zone, move the camera
            _camera.position = new Vector3(_camera.position.x, cameraChange, _camera.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the collided object is the player
        if (other.gameObject == _player.gameObject)
        {
            // If the player exits the trigger zone, reset the camera
            _camera.position = new Vector3(_camera.position.x, 0, _camera.position.z);
        }
    }
}