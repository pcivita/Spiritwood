using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLever : MonoBehaviour
{

    public GameObject sPlatform;
    public Animator animator;

    void Start() {
        animator = sPlatform.GetComponent<Animator>();
    }

    public void makePermanent()
    {
        SpiritPlatform platformScript = sPlatform.GetComponent<SpiritPlatform>();
        platformScript.alwaysOn = true;
        sPlatform.layer = LayerMask.NameToLayer("Ground");
        animator.SetBool("alwaysOn", true);

    }
}
