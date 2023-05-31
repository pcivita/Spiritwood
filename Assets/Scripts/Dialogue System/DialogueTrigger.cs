using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueList dialogueList;
    private int count;
    public bool cutscene = false;


    public void TriggerDialogue () {
        count++;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueList, count, cutscene);
    }
}
