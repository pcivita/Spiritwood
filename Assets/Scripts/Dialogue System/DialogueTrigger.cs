using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueList dialogueList;
    private int count;
    public static bool cutscene = true;


    public void TriggerDialogue () {
        count++;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueList, count, cutscene);
        cutscene = false;
    }
}
