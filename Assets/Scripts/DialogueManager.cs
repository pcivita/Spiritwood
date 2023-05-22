using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    private Dialogue dialogue;
    public FloatRef Speed;
    
    public bool inSentence = false;

    private Queue<string> sentences;

    public TopDownMovement playerMovement;
   
    void Update() {
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)) {
            if (inSentence) {
                Speed.value = 0.01f;
            } else {
                DisplayNextSentence();
            }
           
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Speed.value = 0.05f;
        sentences = new Queue<string>();
    }

    public void StartDialogue (DialogueList dialogueList, int count) {
        playerMovement.movementEnabled = false;
        playerMovement.inConversation = true;
        dialogueBox.SetActive(true);
        if (dialogueList.dialogues.Count == 1) {
            dialogue = dialogueList.dialogues[0];
        } else {
            int index = Random.Range(0, dialogueList.dialogues.Count);
            dialogue = dialogueList.dialogues[count % dialogueList.dialogues.Count];
        }
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
  

    }

    public void DisplayNextSentence () {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
    string sentence = sentences.Dequeue();
    // This is if user tries to skip sentence
    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence, Speed));
    
    }

    IEnumerator TypeSentence (string sentence, FloatRef speed) {
        inSentence = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
          //  Debug.Log(speed);
            // wait a frame;
            yield return new WaitForSeconds(speed.value);
        }
        speed.value = 0.05f;
        inSentence = false;

    }
    
    void EndDialogue () {
        playerMovement.movementEnabled = true;
        playerMovement.inConversation = false;
        dialogueBox.SetActive(false);
        Debug.Log("End of Convo");
    }

    
}
