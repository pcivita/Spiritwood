using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDialogueTrigger : MonoBehaviour
{
    public DialogueList dialogueList;
    private int count; 

    public void TriggerDialogue () {
        count++;
        FindObjectOfType<PlatformDialogueManager>().StartDialogue(dialogueList, count);
    }
}
