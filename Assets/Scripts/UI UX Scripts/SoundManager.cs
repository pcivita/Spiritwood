using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, releaseSpiritSound, backSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip> ("jump_sound");
        releaseSpiritSound = Resources.Load<AudioClip> ("become_spirit");
        backSound = Resources.Load<AudioClip> ("back_to_body");

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
        }
    }
}
