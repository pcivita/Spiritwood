using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, releaseSpiritSound, backSound;
    public static AudioClip toBrightSound, collectSound, switchSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip> ("jump_sound");
        releaseSpiritSound = Resources.Load<AudioClip> ("become_spirit");
        backSound = Resources.Load<AudioClip> ("back_to_body");

        collectSound = Resources.Load<AudioClip> ("collect");
        switchSound = Resources.Load<AudioClip> ("switch");
        toBrightSound = Resources.Load<AudioClip> ("not evil");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch(clip) {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "release_spirit":
                audioSrc.PlayOneShot(releaseSpiritSound);
                break;
            case "back_to_body":
                audioSrc.PlayOneShot(backSound);
                break;
            case "not_evil":
                audioSrc.PlayOneShot(toBrightSound);
                break;
            case "collect":
                audioSrc.PlayOneShot(collectSound);
                break;
            case "switch":
                audioSrc.PlayOneShot(switchSound);
                break;
        }
    }
}