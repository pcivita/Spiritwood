using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoScroll : MonoBehaviour
{
    float speed = 20.0f;
    // float textPosBegin = -992.0f;
    float boundaryTextEnd = 700.0f;

    RectTransform myGorectTransform;
    // [SerializeField]
    // TextMeshProUGUI mainText;

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
