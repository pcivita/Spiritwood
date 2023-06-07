using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScroller : MonoBehaviour
{
    float speed = 30.0f;
    // float imagePosBegin = -1550.0f;
    float boundaryTextEnd = 900.0f;

    RectTransform myGorectTransform;

    // [SerializeField]
    // Image image;

    // [SerializeField]
    // bool isLooping = false;
    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        while(myGorectTransform.localPosition.y < boundaryTextEnd) {
            myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
