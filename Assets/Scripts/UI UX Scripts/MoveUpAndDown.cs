using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
  public float bobbingSpeed = 0.5f;
    public float bobbingAmount = 0.5f;
    private Vector3 _originalPosition;
    private float _timeOffset;

    void Start()
    {
        _originalPosition = transform.localPosition;
        _timeOffset = Random.Range(0f, Mathf.PI * 2);
    }

    void Update()
    {
        float yPositionOffset = Mathf.Sin(Time.time * bobbingSpeed + _timeOffset) * bobbingAmount;
        transform.localPosition = new Vector3(_originalPosition.x, _originalPosition.y + yPositionOffset, _originalPosition.z);
    }
}
