using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLever : MonoBehaviour
{

    public GameObject sPlatform;



    public void makePermanent()
    {
        SpiritPlatform platformScript = sPlatform.GetComponent<SpiritPlatform>();
        platformScript.alwaysOn = true;
    }
}
