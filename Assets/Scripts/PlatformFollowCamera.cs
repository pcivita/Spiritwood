using System;
using TarodevController;
using UnityEngine;

public class PlatformFollowCamera : MonoBehaviour {
    [SerializeField] private Transform _player;
    // [SerializeField] private float _smoothTime = 0.3f;
    // [SerializeField] private Vector3 _offset = new Vector3(0, 1);
    // [SerializeField] private float _lookAheadDistance = 2;
    // [SerializeField] private float _lookAheadSpeed = 1;

    // private Vector3 _velOffset;
    // private Vector3 _vel;
    // private IPlayerController _playerController;
    // private Vector3 _lookAheadVel;

    // private void Awake() => _player.TryGetComponent(out _playerController);

    // private void LateUpdate() {
    //     if (_playerController != null) {
    //         var projectedPos = _playerController.Velocity.normalized * _lookAheadDistance;
    //         _velOffset = Vector3.SmoothDamp(_velOffset, projectedPos, ref _lookAheadVel, _lookAheadSpeed);
    //     }

    //     Step(_smoothTime);
    // }

    // private void OnValidate() => Step(0);

    // private void Step(float time) {
    //     var goal = _player.position + _offset + _velOffset;
    //     goal.z = -10;
    //     transform.position = Vector3.SmoothDamp(transform.position, goal, ref _vel, time);
    // }

    void Update() {
         if (_player.position.y > 5)
        {
            // Adjust the camera's Y position to match the player's
            transform.position = new Vector3(transform.position.x, _player.position.y, transform.position.z);
        }
    }
}