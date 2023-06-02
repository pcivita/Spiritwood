using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritObjectAnimation : MonoBehaviour
{

    public Animator animator;
    public PlatformMovement pm;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("spiritMode", pm.spiritMode);
    }
}